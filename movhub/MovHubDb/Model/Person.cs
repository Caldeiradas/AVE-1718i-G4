﻿namespace MovHubDb.Model
{
    public class Person
    {
        public string birthday { get; set; }
        public string name { get; set; }
        public int imdb_id { get; set; }
    }

    public class Date
    {
        private int Year;
        private int Month;
        private int Day;

        /*
        public Data (string val){
            Year = int.Parse(val.Substring(0).EndsWith("-"))
        }
        */
    }
}
