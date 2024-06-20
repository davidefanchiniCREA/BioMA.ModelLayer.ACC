//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:2.0.50727.5477
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

/// This class was created from file F:\Components\DiseasesComponent\Nuova architettura\CRA.DiseaseProgress\CRA.Diseases.Airborne.DiseaseProgress.Interfaces\XML files\States.xml
/// DCC - Domain Class Coder, http://agsys.cra-cin.it/tools , see Applications, DCC
// 

using CRA.ModelLayer.ParametersManagement;

namespace CRA.Diseases.Airborne.DiseaseProgress.Interfaces
{
    using System;
    using System.Collections.Generic;
    using CRA.ModelLayer.Core;
    using System.Reflection;
    
    
    
    /// <summary>States Domain class contains the accessors to values</summary>
    public class States : ICloneable, IDomainClass
    {
        
        #region Private fields
        private double _HostTissueLatentDaily;
        
        private double _HostTissueVisibleDaily;
        
        private double _HostTissueInfectiousDaily;
        
        private double _HostTissueOldDaily;
        
        private double _IncubationProgressDaily;
        
        private double _LatencyProgressDaily;
        
        private double _InfectiousnessProgressDaily;
        
        private double _NewInfectedTissueDaily;
        
        private int _ConsecutiveDryLeafHours;
        
        private int _LeafWetnessDuration;
        
        private int _InfectionFavourableHours;
        
        private int _ConsecutiveUnfavourableHours;
        
        private double _HostTissueDiseasedDaily;
        
        private double _HostTissueAffectedDaily;
        
        private double _DiseaseInfectionCompositeIndex;

        private Dictionary<string, Cohort> _CohortsList = new Dictionary<string, Cohort>();

        private Dictionary<string, CohortInfection> _CohortsInfection = new Dictionary<string, CohortInfection>();

        private Dictionary<List<double>, int[]> _Cohorts = new Dictionary<List<double>, int[]>();
        #endregion
        
        #region Private field for properties
        private ParametersIO _parametersIO;
        #endregion
        
        #region Constructor
        /// <summary>No parameters constructor</summary>
        public States()
        {
            _parametersIO = new ParametersIO(this);
        }
        #endregion
        
        #region Public properties
        /// <summary>Proportion of the host tissue with latent infections (not yet visible) compared to the total host tissue.</summary>
        public double HostTissueLatentDaily
        {
            get
            {
                return this._HostTissueLatentDaily;
            }
            set
            {
                this._HostTissueLatentDaily = value;
            }
        }
        
        /// <summary>Proportion of the host tissue with visible no sporulating symptoms compared to the total host tissue.</summary>
        public double HostTissueVisibleDaily
        {
            get
            {
                return this._HostTissueVisibleDaily;
            }
            set
            {
                this._HostTissueVisibleDaily = value;
            }
        }
        
        /// <summary>Proportion of the host tissue with sporulating lesions compared to the total host.</summary>
        public double HostTissueInfectiousDaily
        {
            get
            {
                return this._HostTissueInfectiousDaily;
            }
            set
            {
                this._HostTissueInfectiousDaily = value;
            }
        }
        
        /// <summary>Proportion of the host tissue with no longer sporulating lesions (old and sterile) compared to the total host tissue.</summary>
        public double HostTissueOldDaily
        {
            get
            {
                return this._HostTissueOldDaily;
            }
            set
            {
                this._HostTissueOldDaily = value;
            }
        }
        
        /// <summary>Accomplished portion of incubation period still in progress.</summary>
        public double IncubationProgressDaily
        {
            get
            {
                return this._IncubationProgressDaily;
            }
            set
            {
                this._IncubationProgressDaily = value;
            }
        }
        
        /// <summary>Accomplished portion of latent period still in progress.</summary>
        public double LatencyProgressDaily
        {
            get
            {
                return this._LatencyProgressDaily;
            }
            set
            {
                this._LatencyProgressDaily = value;
            }
        }
        
        /// <summary>Accomplished portion of infectious period still in progress.</summary>
        public double InfectiousnessProgressDaily
        {
            get
            {
                return this._InfectiousnessProgressDaily;
            }
            set
            {
                this._InfectiousnessProgressDaily = value;
            }
        }
        
        /// <summary>Proportion of the host tissue which enters the latent state compared to the total host tissue.</summary>
        public double NewInfectedTissueDaily
        {
            get
            {
                return this._NewInfectedTissueDaily;
            }
            set
            {
                this._NewInfectedTissueDaily = value;
            }
        }
        
        /// <summary>Consecutive hours of dry leaves</summary>
        public int ConsecutiveDryLeafHours
        {
            get
            {
                return this._ConsecutiveDryLeafHours;
            }
            set
            {
                this._ConsecutiveDryLeafHours = value;
            }
        }
        
        /// <summary>Duration of leaf wetness period</summary>
        public int LeafWetnessDuration
        {
            get
            {
                return this._LeafWetnessDuration;
            }
            set
            {
                this._LeafWetnessDuration = value;
            }
        }
        
        /// <summary>Number of hours with air relative humidity above the critical air relative humidity.</summary>
        public int InfectionFavourableHours
        {
            get
            {
                return this._InfectionFavourableHours;
            }
            set
            {
                this._InfectionFavourableHours = value;
            }
        }
        
        /// <summary>Consecutive hours with air relative humidity below the critical air relative humidity.</summary>
        public int ConsecutiveUnfavourableHours
        {
            get
            {
                return this._ConsecutiveUnfavourableHours;
            }
            set
            {
                this._ConsecutiveUnfavourableHours = value;
            }
        }
        
        /// <summary>Proportion of the host tissue diseased compared to the total host tissue.</summary>
        public double HostTissueDiseasedDaily
        {
            get
            {
                return this._HostTissueDiseasedDaily;
            }
            set
            {
                this._HostTissueDiseasedDaily = value;
            }
        }
        
        /// <summary>Proportion of the host tissue affected by the disease (included latent tissue) compared to the total host tissue.</summary>
        public double HostTissueAffectedDaily
        {
            get
            {
                return this._HostTissueAffectedDaily;
            }
            set
            {
                this._HostTissueAffectedDaily = value;
            }
        }
        
        /// <summary>Disease infection composite index state</summary>
        public double DiseaseInfectionCompositeIndex
        {
            get
            {
                return this._DiseaseInfectionCompositeIndex;
            }
            set
            {
                this._DiseaseInfectionCompositeIndex = value;
            }
        }

        /// <summary>List of cohorts</summary>
        public Dictionary<string, Cohort> CohortsList
        {
            get
            {
                return this._CohortsList;
            }
            set
            {
                this._CohortsList = value;
            }
        }

        /// <summary>List of cohorts infection</summary>
        public Dictionary<string, CohortInfection> CohortsInfection
        {
            get
            {
                return this._CohortsInfection;
            }
            set
            {
                this._CohortsInfection = value;
            }
        }

        /// <summary>List of cohorts infection</summary>
        public Dictionary<List<double>, int[]> Cohorts
        {
            get
            {
                return this._Cohorts;
            }
            set
            {
                this._Cohorts = value;
            }
        }
       

       
        #endregion
        
        #region IDomainClass members
        /// <summary>Domain Class description</summary>
        public virtual  string Description
        {
            get
            {
                return "Domain classStatesVarInfo States variables of DiseasesProgress component ";
            }
        }
        
        /// <summary>Domain Class URL</summary>
        public virtual  string URL
        {
            get
            {
                return "http://";
            }
        }
        
        /// <summary>Domain Class Properties</summary>
        public virtual IDictionary<string, PropertyInfo> PropertiesDescription
        {
            get
            {
                return _parametersIO.GetCachedProperties(typeof(IDomainClass));
            }
        }
        #endregion
        
        /// <summary>Clears the values of the properties of the domain class by using the default value for the type of each property (e.g '0' for numbers, 'the empty string' for strings, etc.)</summary>
        public virtual Boolean ClearValues()
        {
            _HostTissueLatentDaily = default(System.Double);
            _HostTissueVisibleDaily = default(System.Double);
            _HostTissueInfectiousDaily = default(System.Double);
            _HostTissueOldDaily = default(System.Double);
            _IncubationProgressDaily = default(System.Double);
            _LatencyProgressDaily = default(System.Double);
            _InfectiousnessProgressDaily = default(System.Double);
            _NewInfectedTissueDaily = default(System.Double);
            _ConsecutiveDryLeafHours = default(System.Int32);
            _LeafWetnessDuration = default(System.Int32);
            _InfectionFavourableHours = default(System.Int32);
            _ConsecutiveUnfavourableHours = default(System.Int32);
            _HostTissueDiseasedDaily = default(System.Double);
            _HostTissueAffectedDaily = default(System.Double);
            _DiseaseInfectionCompositeIndex = default(System.Double);
            _Cohorts = new Dictionary<List<double>, int[]>();
            _CohortsList = new Dictionary<string, Cohort>();
            _CohortsInfection = new Dictionary<string, CohortInfection>();
            // Returns true if everything is ok
            return true;
        }
        
        #region Clone
        /// <summary>Implement ICloneable.Clone()</summary>
        public virtual Object Clone()
        {
            // Shallow copy by default
            IDomainClass myclass = (IDomainClass) this.MemberwiseClone();
            _parametersIO.PopulateClonedCopy(myclass);
            return myclass;
        }
        #endregion
    }
}
