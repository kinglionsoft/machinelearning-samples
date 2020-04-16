// This file was auto-generated by ML.NET Model Builder. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ML;
using LandUseML.Model;
using System.IO;
using System.Reflection;

namespace LandUseML.Model
{
    public class ConsumeModel
    {
        // For more info on consuming ML.NET models, visit https://aka.ms/model-builder-consume
        // Method for consuming model in your app
        public static ModelOutput Predict(ModelInput input)
        {
            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Register NormalizeMapping
            mlContext.ComponentCatalog.RegisterAssembly(typeof(NormalizeMapping).Assembly);

            // Register LabelMapping
            mlContext.ComponentCatalog.RegisterAssembly(typeof(LabelMapping).Assembly);

            // Load model & create prediction engine
            string modelPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),"MLModel.zip");
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            // Use model to make prediction on input data
            ModelOutput result = predEngine.Predict(input);
            return result;
        }
    }
}
