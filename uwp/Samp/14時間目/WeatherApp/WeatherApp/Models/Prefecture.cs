using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//追加
using System.Runtime.Serialization;

namespace WeatherApp.Models
{
    /// <summary>
    /// 都道府県管理クラス
    /// </summary>
    [DataContract]
    class Prefecture
    {
        /// <summary>
        /// 都道府県名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 都道府県に対応する市町村メンバー
        /// </summary>
        [DataMember]
        public List<City>  Cities { get; set; }
    }

    /// <summary>
    /// 市町村管理クラス
    /// </summary>
    [DataContract]
    class City
    {
        /// <summary>
        /// 市町村ID
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 市町村名
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
