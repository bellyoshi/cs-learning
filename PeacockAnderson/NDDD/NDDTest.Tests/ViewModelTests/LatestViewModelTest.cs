using NDDD.WinForm.ViewModels;
using NDDD.Domain.Repositories;
using NDDD.Domain.Entities;
namespace NDDTest.Tests.ViewModelTests;


[TestClass]
public class LatestViewModelTest
{

    [TestMethod]
    public void シナリオ()
    {



        // モックのデータを作成
        var entity = new MeasureEntity(
            1,
            Convert.ToDateTime("2012/12/12 12:34:56"),
            12.34f);

        // Moqセット
        var measureMock = new Mock<IMeasureRepository>();
        measureMock.Setup(x => x.GetLatest()).Returns(entity);

        var vm = new LatestViewModel(measureMock.Object);

        vm.Search();
        vm.AreaIdText.Is("0001");
        vm.MeasureDateText.Is("2012/12/12 12:34:56");
        vm.MeasureValueText.Is("12.34℃");



    }
}
