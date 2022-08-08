using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NDDD.WinForm.ViewModels; 
/// <summary>
/// ViewModelとViewをバインドするための基底クラス
/// </summary>
public abstract class ViewModelBase : INotifyPropertyChanged {

    // イベントハンドラ
    public event PropertyChangedEventHandler? PropertyChanged;


    /// <summary>
    /// MVVM支援ツールのprismのバインダブルコードを参考に
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="field"></param>
    /// <param name="value"></param>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    protected bool SetProperty<T>(ref T field,
        T value, [CallerMemberName]string? propertyName = null) {
        if (Equals(field, value)) {
            return false;
        }
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        return true;
    }

    /// <summary>
    /// メソッドにすることで上書きできる
    /// </summary>
    /// <returns></returns>
    public virtual DateTime GetDateTime() {
        return DateTime.Now;
    }

    //todo:public void OnPropertyChanged() {
    //    PropertyChanged.Invoke(
    //        this,
    //        new PropertyChangedEventArgs(""));
    //}

}



