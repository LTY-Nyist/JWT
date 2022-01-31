// See https://aka.ms/new-console-template for more information
using System.Text;
string jwt = Console.ReadLine(); 
string[] segments = jwt.Split('.');
string head = JwtDecode(segments[0]);
string payload = JwtDecode(segments[1]);
string sign = JwtDecode(segments[2]);
Console.WriteLine("---head---");
Console.WriteLine(head);
Console.WriteLine("---payload---");
Console.WriteLine(payload);
Console.WriteLine("---sign---");
Console.WriteLine(sign);
string JwtDecode(string s)
{
	s = s.Replace('-', '+').Replace('_', '/');
	switch (s.Length % 4)
	{
		case 2:
			s += "==";
			break;
		case 3:
			s += "=";
			break;
	}
	var bytes = Convert.FromBase64String(s);
	return Encoding.UTF8.GetString(bytes);
}