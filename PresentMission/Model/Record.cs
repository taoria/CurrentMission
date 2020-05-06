using System;

namespace PresentMission.Model{
    [Serializable]
    public class Record :IComparable<Record>{
        public DateTime Time{ get; set; }
        public string DoneMission{ get; set; }
        public int CompareTo(Record other){
            return Time.CompareTo(other);
        }
    }
}