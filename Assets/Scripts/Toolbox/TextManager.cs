using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
namespace Toolbox
{
    public class TextManager : XSingleton<TextManager>
    {
        //数据库文件储存地址
        string appDBPath = Application.streamingAssetsPath + "/data.db";
        DbAccess db;
        public TextManager()
        {
            db = new DbAccess(@"Data Source=" + appDBPath);
            Debug.Log("yyyyyyyyyyyyyyuuuuuuuuuuuuuu");
        }

        public string GetWord(int id)
        {
            string txt = "";
            using (SqliteDataReader sqReader = db.SelectWhere("config", new string[] { "txt" }, new string[] { "id" }, new string[] { "=" }, new string[] { id.ToString() }))
            {
                while (sqReader.Read())
                {
                    txt = sqReader.GetString(sqReader.GetOrdinal("txt"));
                }
                sqReader.Close();
            }
            return txt;
        }

    }
}