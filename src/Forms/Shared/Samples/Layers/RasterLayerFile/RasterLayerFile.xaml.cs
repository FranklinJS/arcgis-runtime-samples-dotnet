﻿// Copyright 2017 Esri.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at: http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific
// language governing permissions and limitations under the License.

using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Rasters;
using ArcGISRuntimeXamarin.Managers;
using System;
using Xamarin.Forms;
using System.IO;
using Esri.ArcGISRuntime.Geometry;

namespace ArcGISRuntimeXamarin.Samples.RasterLayerFile
{
    public partial class RasterLayerFile : ContentPage
    {
        public RasterLayerFile()
        {
            InitializeComponent();

            // Call a function to set up the map
            Initialize();
        }

        private async void Initialize()
        {
            // Add an imagery basemap
            Map myMap = new Map(Basemap.CreateImagery());

            // Wait for the map to load
            await myMap.LoadAsync();

            // Get the file name
            String filepath = GetRasterPath();

            // Load the raster file
            Raster myRasterFile = new Raster(filepath);

            // Create the layer
            RasterLayer myRasterLayer = new RasterLayer(myRasterFile);

            // Add the layer to the map
            myMap.OperationalLayers.Add(myRasterLayer);

            // Wait for the layer to load
            await myRasterLayer.LoadAsync();

            // Set the viewpoint
            myMap.InitialViewpoint = new Viewpoint(myRasterLayer.FullExtent);

            // Add map to the mapview
            MyMapView.Map = myMap;
        }

        private string GetRasterPath()
        {
            #region offlinedata

            // The desired raster is expected to be called Shasta.tif
            // The ID is 7c4c679ab06a4df19dc497f577f111bd
            string filename = "Shasta.tif";

            // The data manager provides a method to get the folder
            string folder = DataManager.GetDataFolder();

            // Get the full path
            return Path.Combine(folder, "SampleData", "RasterLayerFile", "raster-file", filename);

            #endregion offlinedata
        }
    }
}