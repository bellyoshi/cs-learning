using NDDD.WinForm.ViewModels;


namespace NDDTest.Tests.ViewModelTests;


[TestClass]
public class LatestViewModelTest
{

    [TestMethod]
    public void シナリオ()
    {
        var vm = new LatestViewModel();
        vm.Search();
        vm.AreaIdText.Is("001");
        vm.MeasureDateText.Is("2012/12/12 12:34:56");
        vm.MeasureValueText.Is("12.34℃");

        //// モックのデータを作成
        //var entity = new MeasureEntity(
        //    1,
        //    Convert.ToDateTime("2020/05/26 22:00:00"),
        //    12.34f);

        //// Moqセット
        //var measureMock = new Mock<IMeasureRepository>();
        //measureMock.Setup(x => x.GetLatest()).Returns(entity);

        //var vm = new LatestViewModel(measureMock.Object);
        //// エリアID
        //// 計測日時
        //// 計測値




    }
}
