//namespace Nextodon;

//public static class RuleExtensionMethods
//{
//    public static Grpc.Rule ToGrpc(this Nextodon.Data.Rule i)
//    {
//        var v = new Grpc.Rule
//        {
//            Id = i.Id,
//            Text = i.Text,
//        };

//        return v;
//    }

//    public static Grpc.Rules ToGrpc(this IEnumerable<Nextodon.Data.Rule>? i)
//    {
//        var rules = new Grpc.Rules();

//        if (i != null)
//        {
//            foreach (var r in i)
//            {
//                rules.Data.Add(r.ToGrpc());
//            }
//        }

//        return rules;
//    }
//}
