using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.WinForm.ViewModels
{
    public class LatestViewModel
    {
        private readonly IMeasureRepository _measureRepository;

        private MeasureEntity _measure;

        public LatestViewModel(IMeasureRepository measureRepository)
        {
            this._measureRepository=measureRepository;
        }

        public string AreaIdText
        {
            get => _measure != null ? _measure.AreaId.ToString().PadLeft(4, '0') : String.Empty;
        }
        public string MeasureDateText
        {
            get => _measure != null ? _measure.MeasureDate.ToString("yyyy/MM/dd HH:mm:ss") : String.Empty;
        }
        public string MeasureValueText {
            get => _measure != null ? Math.Round(_measure.MeasureValue, 2) + "℃" : String.Empty;
        }

        public void Search()
        {
            _measure = _measureRepository.GetLatest();
        }
    }
}
