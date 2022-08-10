using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.WinForm.ViewModels
{
    public class LatestViewModel : ViewModelBase 
    {
        private readonly IMeasureRepository _measureRepository;

        private string _areaIdText = string.Empty;
        private string _measureDateText = string.Empty;
        private string _measureValueText = string.Empty;

        public LatestViewModel(IMeasureRepository measureRepository)
        {
            this._measureRepository=measureRepository;
        }

        public string AreaIdText { 
            get => _areaIdText; 
            set => SetProperty(ref _areaIdText, value);
        }
        
        public string MeasureDateText

        {
            get => _measureDateText;
            set => SetProperty(ref _measureDateText, value);
        }

        public string MeasureValueText {
            get => _measureValueText;
            set => SetProperty(ref _measureValueText, value);
        }

        public void Search()
        {
            var measure = _measureRepository.GetLatest();
            AreaIdText = measure.AreaId.ToString().PadLeft(4, '0');
            MeasureDateText = measure.MeasureDate.ToString("yyyy/MM/dd HH:mm:ss");
            MeasureValueText = Math.Round(measure.MeasureValue, 2) + "℃";
            OnPropertyChanged();
        }
    }
}
