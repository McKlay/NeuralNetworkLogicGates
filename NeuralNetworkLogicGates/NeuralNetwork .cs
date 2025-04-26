using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkLogicGates
{
    class NeuralNetwork
    {
        int inputSize;
        int hiddenSize;
        int outputSize;

        double[] inputLayer;
        double[] hiddenLayer;
        double[] outputLayer;

        double[,] weightsInputHidden;
        double[,] weightsHiddenOutput;

        double[] biasHidden;
        double[] biasOutput;

        double learningRate = 0.1;
        public List<double> LossPerEpoch = new List<double>();

        public NeuralNetwork(int inputSize, int hiddenSize, int outputSize)
        {
            this.inputSize = inputSize;
            this.hiddenSize = hiddenSize;
            this.outputSize = outputSize;

            inputLayer = new double[inputSize];
            hiddenLayer = new double[hiddenSize];
            outputLayer = new double[outputSize];

            weightsInputHidden = new double[inputSize, hiddenSize];
            weightsHiddenOutput = new double[hiddenSize, outputSize];

            biasHidden = new double[hiddenSize];
            biasOutput = new double[outputSize];

            InitializeWeights();
        }

        void InitializeWeights()
        {
            Random rand = new Random();

            for (int i = 0; i < inputSize; i++)
                for (int j = 0; j < hiddenSize; j++)
                    weightsInputHidden[i, j] = rand.NextDouble() * 2 - 1;

            for (int i = 0; i < hiddenSize; i++)
                for (int j = 0; j < outputSize; j++)
                    weightsHiddenOutput[i, j] = rand.NextDouble() * 2 - 1;

            for (int i = 0; i < hiddenSize; i++)
                biasHidden[i] = rand.NextDouble() * 2 - 1;

            for (int i = 0; i < outputSize; i++)
                biasOutput[i] = rand.NextDouble() * 2 - 1;
        }

        public double[] Forward(double[] input)
        {
            if (input.Length != inputSize)
                throw new ArgumentException("Input size mismatch.");

            // Copy input to inputLayer
            for (int i = 0; i < inputSize; i++)
                inputLayer[i] = input[i];

            // Input to Hidden
            for (int j = 0; j < hiddenSize; j++)
            {
                double sum = biasHidden[j];
                for (int i = 0; i < inputSize; i++)
                    sum += inputLayer[i] * weightsInputHidden[i, j];

                hiddenLayer[j] = Sigmoid(sum);
            }

            // Hidden to Output
            for (int k = 0; k < outputSize; k++)
            {
                double sum = biasOutput[k];
                for (int j = 0; j < hiddenSize; j++)
                    sum += hiddenLayer[j] * weightsHiddenOutput[j, k];

                outputLayer[k] = Sigmoid(sum);
            }

            return outputLayer;
        }

        private double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public double Predict(double[] inputs)
        {
            return Forward(inputs)[0];
        }

        public void Train(double[] inputs, double target, double learningRate)
        {
            // Step 1: Forward pass
            double[] outputs = Forward(inputs);
            double output = outputs[0];

            // Step 2: Compute error
            double error = target - output;

            // Step 3: Output layer gradient and weight update
            double[] outputGradients = new double[outputSize];

            for (int k = 0; k < outputSize; k++)
            {
                outputGradients[k] = error * outputLayer[k] * (1 - outputLayer[k]);
                for (int j = 0; j < hiddenSize; j++)
                {
                    weightsHiddenOutput[j, k] += learningRate * outputGradients[k] * hiddenLayer[j];
                }
                biasOutput[k] += learningRate * outputGradients[k];
            }

            // Step 4: Hidden layer gradient and weight update
            double[] hiddenGradients = new double[hiddenSize];

            for (int j = 0; j < hiddenSize; j++)
            {
                double sum = 0;
                for (int k = 0; k < outputSize; k++)
                {
                    sum += outputGradients[k] * weightsHiddenOutput[j, k];
                }
                hiddenGradients[j] = sum * hiddenLayer[j] * (1 - hiddenLayer[j]);

                for (int i = 0; i < inputSize; i++)
                {
                    weightsInputHidden[i, j] += learningRate * hiddenGradients[j] * inputLayer[i];
                }
                biasHidden[j] += learningRate * hiddenGradients[j];
            }
        }
        public double EvaluateAccuracy(List<(double[] inputs, double target)> data)
        {
            int correct = 0;
            foreach (var (inputs, target) in data)
            {
                double prediction = Predict(inputs);
                double predictedBinary = prediction >= 0.5 ? 1.0 : 0.0;
                if (predictedBinary == target)
                    correct++;
            }
            return (double)correct / data.Count;
        }

    }
}
