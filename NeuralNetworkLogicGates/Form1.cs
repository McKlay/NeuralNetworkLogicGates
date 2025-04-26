namespace NeuralNetworkLogicGates
{
    public partial class Form1 : Form
    {
        NeuralNetwork nn;
        private string lastTrainedGate = "";
        public Form1()
        {
            InitializeComponent();
            nn = new NeuralNetwork(5, 4, 1); // 5-input, 4-hidden, 1-output (for binary gate)

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxGate.Items.Add("AND");
            comboBoxGate.Items.Add("OR");
            comboBoxGate.Items.Add("XOR");
            comboBoxGate.SelectedIndex = 0; // Default: AND
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            string currentGate = comboBoxGate.SelectedItem.ToString();

            if (nn.LossPerEpoch.Count == 0 || lastTrainedGate != currentGate)
            {
                MessageBox.Show("Please train the network for the selected gate before predicting.");
                return;
            }

            double[] input = new double[5];
            input[0] = chkInput0.Checked ? 1.0 : 0.0;
            input[1] = chkInput1.Checked ? 1.0 : 0.0;
            input[2] = chkInput2.Checked ? 1.0 : 0.0;
            input[3] = chkInput3.Checked ? 1.0 : 0.0;
            input[4] = chkInput4.Checked ? 1.0 : 0.0;

            double[] output = nn.Forward(input);

            // Optional: threshold at 0.5 for binary decision
            int result = output[0] >= 0.5 ? 1 : 0;

            lblOutput.Text = $"Output: {result} (raw: {output[0]:F3})";
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            string selectedGate = comboBoxGate.SelectedItem.ToString();
            List<(double[], double)> trainingData = new List<(double[], double)>();

            nn.LossPerEpoch.Clear();

            // Generate all 32 combinations of 5 binary inputs
            for (int i = 0; i < 32; i++)
            {
                double[] input = new double[5];
                for (int bit = 0; bit < 5; bit++)
                {
                    input[bit] = (i & (1 << bit)) != 0 ? 1.0 : 0.0;
                }

                double output = selectedGate switch
                {
                    "AND" => input.All(x => x == 1.0) ? 1.0 : 0.0,
                    "OR" => input.Any(x => x == 1.0) ? 1.0 : 0.0,
                    "XOR" => input.Select(x => (int)x).Aggregate(0, (acc, x) => acc ^ x) == 1 ? 1.0 : 0.0,
                    _ => 0.0
                };

                trainingData.Add((input, output));
            }

            int epochs = 100000;
            double learningRate = 0.1;

            for (int epoch = 0; epoch < epochs; epoch++)
            {
                double epochError = 0;
                foreach (var (input, target) in trainingData)
                {
                    double outputBefore = nn.Predict(input);
                    nn.Train(input, target, learningRate);
                    double error = target - outputBefore;
                    epochError += error * error;
                }
                nn.LossPerEpoch.Add(epochError / trainingData.Count);
            }

            double accuracy = nn.EvaluateAccuracy(trainingData);
            MessageBox.Show($"Training complete!\nGate: {selectedGate}\nAccuracy: {accuracy * 100:F2}%\nFinal Loss: {nn.LossPerEpoch.Last():F4}");

            lastTrainedGate = selectedGate;

        }
    }
}
