<Query Kind="Program">
  <Connection>
    <ID>887b7cfc-025b-431c-83f5-b39a4b71dc12</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>.</Server>
    <Database>DXFullApp</Database>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

//Populate Opportunity table with 3 random opportunities for each contact, using LinqPad. One time use and work is already done. In source control for prosperity.

void Main()
{
	var contacts = Contacts.ToList();
	List<Opportunities> opportunities = Opportunities.ToList();
	var opportunity = new LINQPad.User.Opportunity();
	int NUMBER_OF_OPPORTUNITIES = 3;

	var entities = Opportunity.ToList();
	Opportunity.RemoveRange(entities);
	SaveChanges();

	foreach (var contact in contacts)
	{
		
		var randomList = SelectRandom(opportunities, NUMBER_OF_OPPORTUNITIES);
		foreach (Opportunities item in randomList)
		{
			opportunity = new LINQPad.User.Opportunity();
			opportunity.ContactId = contact.ID;
			opportunity.Name = item.Name;
			opportunity.Price = GetRandomPrice();
			
			Opportunity.Add(opportunity);
			SaveChanges();
		}
		
		opportunities = Opportunities.ToList();
	}
}

public decimal GetRandomPrice()
{
    Random rand = new Random();
    decimal price = rand.Next(900, 5001); 
    return price;
}


	public static List<Opportunities> SelectRandom(List<Opportunities> list, int number)
	{
		Random rand = new Random();
		List<Opportunities> newList = new List<Opportunities>();
		for (int i = 0; i < number; i++)
		{
			int index = rand.Next(list.Count);
			newList.Add(list[index]);
			list.RemoveAt(index);
		}
		return newList;
}
