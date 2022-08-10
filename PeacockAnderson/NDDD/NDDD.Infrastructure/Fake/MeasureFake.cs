using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;

namespace NDDD.Infrastructure.Fake;

internal sealed class MeasureFake : IMeasureRepository
{
    MeasureEntity IMeasureRepository.GetLatest()
    {
        return new MeasureEntity(10, Convert.ToDateTime("2020/12/12 12:34:56"), 123.341f);
    }
}
