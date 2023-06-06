using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;

namespace NDDD.Infrastructure.Fake;

internal sealed class MeasureFake : IMeasureRepository
{
    internal readonly string FakePath = AppSettings.Default.FakePath;
    MeasureEntity IMeasureRepository.GetLatest()
    {
        //return null;
        try
        {
            var filename = System.IO.Path.Combine(FakePath, "MeasureFake.csv");
            var lines = System.IO.File.ReadAllLines(filename);
            var value = lines[0].Split(',');
            return new MeasureEntity(Convert.ToInt32(value[0]), Convert.ToDateTime(value[1]), Convert.ToSingle(value[2]));
        } catch (Exception ex)
        {
            throw new NDDD.Domain.Exceptions.FakeException("MeasureFakeの取得に失敗いたしました。",ex);
            //return new MeasureEntity(10, Convert.ToDateTime("2020/12/12 12:34:56"), 123.341f);
        }
        
    }
}
