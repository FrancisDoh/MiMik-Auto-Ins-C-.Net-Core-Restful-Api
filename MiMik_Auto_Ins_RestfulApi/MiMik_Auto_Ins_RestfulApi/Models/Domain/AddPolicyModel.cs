namespace MiMik_Auto_Ins_RestfulApi.Models.Domain
{
    public class AddPolicyModel
    {
        public string BodInjLabCvg { get; set; }
        public string PropDamLiabCvg { get; set; }
        public string PersInjProtCvg { get; set; }
        public string PolicyState { get; set; }
        public string DateTimeIssued { get; set; }
        public string DateTimeBeginTerm { get; set; }
        public string DateTimeEndTerm { get; set; }
        public string PremiumTermAmount { get; set; }
    }
}
