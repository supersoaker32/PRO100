﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Feature : INotifyPropertyChanged
    {
        public Feature(string featureName = "", string featureDescription = "")
        {
            FeatureName = featureName;
            FeatureDescription = featureDescription;
        }

        public Feature()
        {
            FeatureName = "";
            FeatureDescription = "";
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private String featureName = "FeatureName";

        public String FeatureName
        {
            get { return featureName; }
            set
            {
                featureName = value;
                FieldChanged();
            }
        }

        private String featureDescription = "FeatureDescription";

        public String FeatureDescription
        {
            get { return featureDescription; }
            set
            {
                featureDescription = value;
                FieldChanged();
            }
        }
        protected void FieldChanged([CallerMemberName] string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

        public override string ToString()
        {
            return $"FeatureName:{FeatureName}\n" +
                $"FeatureDescription:{FeatureDescription}\n";
        }
    }
}
