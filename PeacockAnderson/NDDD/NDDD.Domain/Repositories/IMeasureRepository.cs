using NDDD.Domain.Entities;


namespace NDDD.Domain.Repositories;

public interface IMeasureRepository
{
    MeasureEntity GetLatest();
}
