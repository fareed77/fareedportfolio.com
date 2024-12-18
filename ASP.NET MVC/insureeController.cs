public class InsureeController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Insuree/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Insuree/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "FirstName,LastName,Email,Age,CarYear,CarMake,CarModel,SpeedingTickets,DUI,FullCoverage")] Insuree insuree)
    {
        if (ModelState.IsValid)
        {
            // Base price
            double quote = 50;

            // Age-based price adjustment
            if (insuree.Age <= 18)
                quote += 100;
            else if (insuree.Age <= 25)
                quote += 50;
            else
                quote += 25;

            // Car year-based price adjustment
            if (insuree.CarYear < 2000 || insuree.CarYear > 2015)
                quote += 25;

            // Make-based price adjustment
            if (insuree.CarMake.ToLower() == "porsche")
            {
                quote += 25; // Porsche base
                if (insuree.CarModel.ToLower() == "911 carrera")
                    quote += 25; // 911 Carrera additional charge
            }

            // Speeding tickets-based price adjustment
            quote += insuree.SpeedingTickets * 10;

            // DUI-based price adjustment (25% increase)
            if (insuree.DUI)
                quote *= 1.25;

            // Full coverage-based price adjustment (50% increase)
            if (insuree.FullCoverage)
                quote *= 1.50;

            // Save the quote (can store it as part of Insuree model or directly in the database)
            insuree.Quote = quote;

            db.Insurees.Add(insuree);
            db.SaveChanges();

            // Redirect to the details or list page after saving
            return RedirectToAction("Index");
        }

        return View(insuree);
    }

    // GET: Insuree/Index (for the admin view)
    public ActionResult Index()
    {
        var insurees = db.Insurees.ToList();
        return View(insurees);
    }
}