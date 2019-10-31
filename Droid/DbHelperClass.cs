using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database;
using Android.Database.Sqlite;
using ForecastApp.Droid;

namespace Project
{
    public class DbHelperClass : SQLiteOpenHelper
    {
        //Step 1:Declare database name and columns
        private static string _DatabaseName = "mydatabase.db";
        private const string TableName = "forecasts";
        private const string ColumnID = "id";
        private const string ColumnName = "cidade";
        private const string ColumnTemp = "temp";
        private const string ColumnClima = "clima";
        private Data userObj ;


        public const string CreateForecastTableQuery = "Create Table " + TableName + " ("
            + ColumnID + " TEXT,"
            + ColumnClima + " TEXT,"
            + ColumnTemp + " TEXT,"
            + ColumnName + " TEXT )";

        private SQLiteDatabase myDbObj;

        //DbHelperClass Constructor
        public DbHelperClass (Context context) : 
            base(context,name: _DatabaseName, factory: null, version: 1)
        {
            myDbObj = WritableDatabase;
            userObj = new Data();
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            try
            {
                db.ExecSQL(CreateForecastTableQuery); 
            }
            catch(Exception e) {
                System.Console.WriteLine($"Error creating database table. {e.Message}");
            }
            
        }

        //Insert record in database
        public string insertRecord (Data forecast)
        {
            //Insert Statement
            string insertStmt = $"Insert into {TableName} Values ( {forecast.Id}, '{forecast.Weather[0].Description}', '{forecast.Main.Temp}' , '{forecast.Name}')";
            try
            {
                myDbObj.ExecSQL(insertStmt);
                return "Inserido com sucesso";
            }
            catch(Exception e)
            {
                return $"Erro ao inserir  {e.Message}";
            }
            
        }

        //Select records from database
        public List<Data> selectRecords()
        {
            try
            {
                List<Data> userList = new List<Data>();
                ICursor myDBData = myDbObj.RawQuery($"Select * from {TableName}", null);

                while (myDBData.MoveToNext())
                {
                    userObj.Id = myDBData.GetString(myDBData.GetColumnIndexOrThrow(ColumnID));
                    userObj.Name = myDBData.GetString(myDBData.GetColumnIndexOrThrow(ColumnName));
                    userObj.Weather.Add(new Weather(myDBData.GetString(myDBData.GetColumnIndexOrThrow(ColumnClima))));
                    userObj.Main.Temp = myDBData.GetString(myDBData.GetColumnIndexOrThrow(ColumnTemp));

                    userList.Add(userObj);
                }
                return userList;
            }catch(Exception e)
            {
                System.Console.WriteLine($"Error selecting records from database. {e.Message}");
                return null;
            }
           
        }

        public string deleteRecord(string id)
        {
            string deleteStmt = $"DELETE FROM {TableName} WHERE id= {id};";
            try
            {
                myDbObj.ExecSQL(deleteStmt);
                return "removido com sucesso";
            }
            catch (Exception e)
            {
                return $"Erro ao deletar ";
            }

        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }
    }
}