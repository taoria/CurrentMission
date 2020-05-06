using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PresentMission.Model;

namespace PresentMission.Tool{
    public class RecordResult{
        public SortedSet<Record> Records{ get; set; }
        
        public void Read(string filename){
            string readFromFile;
            using (var file = File.Open(filename, FileMode.OpenOrCreate)){
                using StreamReader streamReader = new StreamReader(file);
                readFromFile = streamReader.ReadToEnd();
            }
            var tempRecord = JsonConvert.DeserializeObject(readFromFile) as SortedSet<Record>;
            if (Records == null){
                Records = tempRecord;
            }
            else{
                if (tempRecord != null){
                    foreach (var record in tempRecord){
                        Records.Add(record);
                    }
                }
 
            }
            
        }

        public void Add(Record record){
            if (Records == null){
                Records = new SortedSet<Record>();
                Records.Add(record);
            }
            else{
                Records.Add(record);
            }
        }
        public void Write(string filename){
            using var file = File.Open(filename, FileMode.OpenOrCreate);
            using StreamWriter streamWriter = new StreamWriter(file);
            streamWriter.Write(JsonConvert.SerializeObject(this.Records));
        }
    }
}