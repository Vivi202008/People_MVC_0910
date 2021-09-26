//namespace People_MVC.Controllers
//{
//    internal class AtriclList
//    {
//        public int PId { get; set; }
//        public string PName { get; set; }
//        public string Phone { get; set; }
//        public string CityName { get; set; }
//        public string CountryName { get; set; }
//        public string PLanguages { get; set; }
//    }
//}


//var query = from a in _context.Persons
//            join b in _context.Cities on a.CityId equals b.CityId
//            join c in _context.Countries on b.CountryId equals c.CountryId
//            join d in _context.PersonLanguages on a.PersonId equals d.PersonId
//            join e in _context.Languages on d.LanguageId equals e.LanguageId
//            select (new AtriclList { PId = a.PersonId, PName = a.Name, Phone = a.TeleNumber, CityName = b.Name, CountryName = c.Name, PLanguages = e.PersonLanguages.ToString() }).ToList();
//return View();

//    @{
//    foreach (var item in Model.people)
//    {
//        < tr >
//                < td > @item.PId </ td >
//                < td > @item.PName </ td >
//                < td > @item.Phone </ td >


//                < td > @item.CityName </ td >
//                < td > @item.CountryName </ td >
//            < td > @item.PLanguages </ td >


//        </ tr > }
//}



//[HttpGet("/countries/display/{id}")]
//public IActionResult DisplayCities(int id)
//{
//    var query = from a in _context.Countries
//                join b in _context.Cities on a.CoutryId equals b.CountryId
//                select b.Name;
//    List<City> CitiesOfCountry = query.ToList();
//    return CitiesOfCountry;
//}

//public string GetCountryName(int personId)
//{
//    var query = from a in _context.Persons
//                join b in _context.Cities on a.CityId equals b.CityId
//                join c in _context.Countries on b.CountryId equals c.CountryId
//                where a.PersonId == personId
//                select c.Name;
//    string CountryName = query.ToString();
//    return CountryName;
//}


//< form class= "create-form" asp - controller = "Cities" asp - action = "CreateCity" method = "post" >


//              < div class= "form-group" >


//                   < label for= "Name" class= "form-text" > Name:</ label >


//                        < input class= "form-control" type = "text" name = "name" value = "" />


//                          </ div >


//                          < div class= "form-group" >


//                               < label for= "CountryId" class= "form-text" > Country:</ label >
//        @*< select class= "form-select" name = "CountryId" asp - items = "ViewBag.Countries" >


//            </ select > *@
//    </ div >
//    < div class= "form-group" >


//         < button class= "btn btn-primary" type = "submit" name = "submit" value = "Create" > Create </ button >


//           </ div >
//       </ form >


//@foreach(var item in Model.people)
//    {
//        @*@await Html.PartialAsync("_ShowAll", item); *@
//     < partial name = "_People.cshtml" model = "item" />


//     }