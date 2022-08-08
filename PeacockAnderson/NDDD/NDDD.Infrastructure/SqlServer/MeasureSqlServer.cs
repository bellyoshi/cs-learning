using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace NDDD.Infrastructure.SqlServer {

    /// <summary>
    /// SqlServer
    /// internalにしFactoris以外からはNewできなくする
    /// </summary>
    internal sealed class MeasureSqlServer : IMeasureRepository {
       
        public MeasureEntity GetLatest() {
            throw new NotImplementedException();
        }

        public IReadOnlyList<MeasureEntity> GetLatests() {
            throw new NotImplementedException();
        }
    }
}
