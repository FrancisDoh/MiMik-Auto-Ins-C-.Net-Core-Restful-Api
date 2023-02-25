namespace MiMik_Auto_Ins_RestfulApi.Models.Domain
{
    public class Policy
    {
        public int policyID { get; set; }
        public string bodInjLabCvg { get; set; }
        public string propDamLiabCvg { get; set; }
        public string persInjProtCvg { get; set; }
        public string policyState { get; set; }
        public string dateTimeIssued { get; set; }
        public string dateTimeBeginTerm { get; set; }
        public string dateTimeEndTerm { get; set; }
        public string PremiumTermAmount { get; set; }
    }
}
