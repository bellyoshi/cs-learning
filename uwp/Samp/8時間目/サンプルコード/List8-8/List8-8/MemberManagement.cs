using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List8_8
{
    /// <summary>
    /// 会員メンバー管理クラス
    /// </summary>
    class MemberManagement
    {
        // 会員メンバー管理用変数
        List<Member> _members = new List<Member>();

        /// <summary>
        /// 新規メンバーを追加する
        /// </summary>
        /// <param name="name">追加するメンバーの氏名</param>
        /// <returns>追加したメンバーの会員ID</returns>
        public string Add(string name)
        {
            int id = GetMemberID(); // 新規会員番号を発番
            return "";
        }

        /// <summary>
        /// 会員IDを採番する
        /// </summary>
        /// <returns>採番した会員ID</returns>
        private int GetMemberID()
        {
            if (_members.Count == 0)
            {
                // 会員数が0なので、会員番号を1で発番する
                return 1;
            }
            
            // 会員番号を「最後の会員番号 + 1」で発番する
            return _members[_members.Count].ID++;
        }

        /// <summary>
        /// 指定した会員IDのデータを取得する
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public Member FindMember(int memberID)
        {
            // LINQのWhereメソッドで指定した会員IDのデータを取得する
            var member =_members.Where(_members => _members.ID == memberID);

            // 指定した会員が見つからなかった場合
            if (member.Count() == 0)
            {
                // 例外を発生させる
                throw new MemberNotFoundException();
            }

            // クエリの実行結果から先頭のデータを取得する
            return member.First();
        }
    }
}
