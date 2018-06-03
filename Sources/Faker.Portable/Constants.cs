﻿namespace Faking
{
	using System;
    using System.Text;

    /// <summary>
    /// Several default values for generation purpose.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Default min number.
        /// </summary>
        public const int DefaultNumberMin = 1;

        /// <summary>
        /// Default max number
        /// </summary>
        public const int DefaultNumberMax = 1024;

        /// <summary>
        /// Maximum property depth before stopping to mock data.
        /// </summary>
        public const int MaxScope = 10;

        /// <summary>
        /// Mininum default date.
        /// </summary>
        public static DateTime DefaultDateTimeMin = DateTime.Now - TimeSpan.FromDays(365);

        /// <summary>
        /// Maximum default date.
        /// </summary>
        public static DateTime DefaultDateTimeMax = DateTime.Now + TimeSpan.FromDays(365);

		/// <summary>
		/// A list of various countries.
		/// </summary>
		public static string[] Countries = { "France", "Argentina", "Democratic Republic of the Congo", "Côte d'Ivoire", "Democratic People's Republic of Korea", "Mali", "Zimbabwe", "United States of America" };

        /// <summary>
        /// Random words for generating text data.
        /// </summary>
        public static string[] AllWords = { "Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit", "Etiam", "ut", "sollicitudin", "ante", "sit", "amet", "consectetur", "eros", "Suspendisse", "accumsan", "turpis", "eu", "mauris", "finibus", "condimentum", "Nunc", "ut", "enim", "sit", "amet", "elit", "imperdiet", "fringilla", "Duis", "eu", "odio", "nisi", "Donec", "quam", "urna", "mattis", "sit", "amet", "blandit", "eget", "viverra", "at", "mauris", "In", "volutpat", "metus", "ac", "tellus", "tincidunt", "condimentum", "Vestibulum", "pretium", "maximus", "lacus", "Quisque", "consequat", "dapibus", "laoreet", "Sed", "cursus", "pretium", "tellus", "ac", "volutpat", "Duis", "sit", "amet", "lectus", "tortor", "Fusce", "euismod", "libero", "eget", "ornare", "ornare", "elit", "dolor", "gravida", "lectus", "ut", "viverra", "quam", "ipsum", "et", "tortor", "Pellentesque", "a", "tempus", "felis", "Aenean", "vel", "massa", "orci", "In", "imperdiet", "blandit", "mauris", "non", "lobortis", "ligula", "facilisis", "nec", "Donec", "id", "velit", "sed", "ipsum", "pharetra", "aliquet", "Morbi", "tincidunt", "felis", "lectus", "et", "congue", "sem", "aliquam", "in", "Etiam", "pharetra", "leo", "quis", "sem", "blandit", "finibus", "Sed", "vel", "leo", "venenatis", "sagittis", "quam", "nec", "fermentum", "lorem", "Cras", "auctor", "odio", "non", "mauris", "gravida", "faucibus", "Vestibulum", "tincidunt", "tincidunt", "leo", "sit", "amet", "auctor", "In", "sit", "amet", "feugiat", "risus", "Vestibulum", "pretium", "ipsum", "ut", "eros", "sagittis", "convallis", "Vestibulum", "tincidunt", "erat", "et", "facilisis", "vestibulum", "Ut", "auctor", "sollicitudin", "mi", "non", "tempor", "metus", "tempor", "vitae", "Suspendisse", "potenti", "Aenean", "imperdiet", "efficitur", "libero", "sit", "amet", "lacinia", "Sed", "sit", "amet", "neque", "id", "ligula", "aliquet", "iaculis", "in", "non", "leo", "Aenean", "viverra", "quam", "vel", "odio", "sodales", "eget", "aliquam", "magna", "volutpat", "Aenean", "hendrerit", "blandit", "ipsum", "et", "aliquet", "lorem", "varius", "et", "Duis", "in", "turpis", "efficitur", "pellentesque", "velit", "ac", "commodo", "nunc", "Aenean", "id", "elit", "magna", "Proin", "pharetra", "arcu", "nibh", "sit", "amet", "tristique", "tellus", "tincidunt", "nec", "Aliquam", "viverra", "turpis", "ac", "nibh", "commodo", "tincidunt", "Mauris", "bibendum", "sem", "magna", "eget", "efficitur", "elit", "viverra", "molestie", "Aliquam", "eu", "enim", "eu", "erat", "imperdiet", "suscipit", "Maecenas", "bibendum" };

		/// <summary>
		/// The firstnames.
		/// </summary>
		public static string[] Firstnames = { "Cleveland", "Shila", "Delicia", "Glady", "Ying", "Lovetta", "Kasey", "Yuko", "Bao", "Dianna", "Clarice", "Herma", "Eldora", "Brenda", "Debbra", "Marcelina", "Tiara", "Audrie", "Treasa", "Cyrus", "Euna", "Tran", "Masako", "Theola", "Edwina", "Jada", "Erich", "Cortez", "Demarcus", "Wilda", "Erlinda", "Jacquelynn", "Dawne", "Karol", "Patrina", "Zofia", "Bula", "Miles", "Eugena", "Lynda", "Gina", "Autumn", "Willie", "Kiana", "Daphne", "Clifton", "Towanda", "Imelda", "Lawanna", "Tomi" };

		/// <summary>
		/// The lastnames.
		/// </summary>
		public static string[] Lastnames = { "Abbott", "Abernathy", "Abshire", "Adams", "Altenwerth", "Anderson", "Ankunding", "Armstrong", "Auer", "Aufderhar", "Bahringer", "Bailey", "Balistreri", "Barrows", "Bartell", "Bartoletti", "Barton", "Bashirian", "Batz", "Bauch", "Baumbach", "Bayer", "Beahan", "Beatty", "Bechtelar", "Becker", "Bednar", "Beer", "Beier", "Berge", "Bergnaum", "Bergstrom", "Bernhard", "Bernier", "Bins", "Blanda", "Blick", "Block", "Bode", "Boehm", "Bogan", "Bogisich", "Borer", "Bosco", "Botsford", "Boyer", "Boyle", "Bradtke", "Brakus", "Braun", "Breitenberg", "Brekke", "Brown", "Bruen", "Buckridge", "Carroll", "Carter", "Cartwright", "Casper", "Cassin", "Champlin", "Christiansen", "Cole", "Collier", "Collins", "Conn", "Connelly", "Conroy", "Considine", "Corkery", "Cormier", "Corwin", "Cremin", "Crist", "Crona", "Cronin", "Crooks", "Cruickshank", "Cummerata", "Cummings", "Dach", "D\"Amore", "Daniel", "Dare", "Daugherty", "Davis", "Deckow", "Denesik", "Dibbert", "Dickens", "Dicki", "Dickinson", "Dietrich", "Donnelly", "Dooley", "Douglas", "Doyle", "DuBuque", "Durgan", "Ebert", "Effertz", "Eichmann", "Emard", "Emmerich", "Erdman", "Ernser", "Fadel", "Fahey", "Farrell", "Fay", "Feeney", "Feest", "Feil", "Ferry", "Fisher", "Flatley", "Frami", "Franecki", "Friesen", "Fritsch", "Funk", "Gaylord", "Gerhold", "Gerlach", "Gibson", "Gislason", "Gleason", "Gleichner", "Glover", "Goldner", "Goodwin", "Gorczany", "Gottlieb", "Goyette", "Grady", "Graham", "Grant", "Green", "Greenfelder", "Greenholt", "Grimes", "Gulgowski", "Gusikowski", "Gutkowski", "Gutmann", "Haag", "Hackett", "Hagenes", "Hahn", "Haley", "Halvorson", "Hamill", "Hammes", "Hand", "Hane", "Hansen", "Harber", "Harris", "Hartmann", "Harvey", "Hauck", "Hayes", "Heaney", "Heathcote", "Hegmann", "Heidenreich", "Heller", "Herman", "Hermann", "Hermiston", "Herzog", "Hessel", "Hettinger", "Hickle", "Hilll", "Hills", "Hilpert", "Hintz", "Hirthe", "Hodkiewicz", "Hoeger", "Homenick", "Hoppe", "Howe", "Howell", "Hudson", "Huel", "Huels", "Hyatt", "Jacobi", "Jacobs", "Jacobson", "Jakubowski", "Jaskolski", "Jast", "Jenkins", "Jerde", "Johns", "Johnson", "Johnston", "Jones", "Kassulke", "Kautzer", "Keebler", "Keeling", "Kemmer", "Kerluke", "Kertzmann", "Kessler", "Kiehn", "Kihn", "Kilback", "King", "Kirlin", "Klein", "Kling", "Klocko", "Koch", "Koelpin", "Koepp", "Kohler", "Konopelski", "Koss", "Kovacek", "Kozey", "Krajcik", "Kreiger", "Kris", "Kshlerin", "Kub", "Kuhic", "Kuhlman", "Kuhn", "Kulas", "Kunde", "Kunze", "Kuphal", "Kutch", "Kuvalis", "Labadie", "Lakin", "Lang", "Langosh", "Langworth", "Larkin", "Larson", "Leannon", "Lebsack", "Ledner", "Leffler", "Legros", "Lehner", "Lemke", "Lesch", "Leuschke", "Lind", "Lindgren", "Littel", "Little", "Lockman", "Lowe", "Lubowitz", "Lueilwitz", "Luettgen", "Lynch", "Macejkovic", "Maggio", "Mann", "Mante", "Marks", "Marquardt", "Marvin", "Mayer", "Mayert", "McClure", "McCullough", "McDermott", "McGlynn", "McKenzie", "McLaughlin", "Medhurst", "Mertz", "Metz", "Miller", "Mills", "Mitchell", "Moen", "Mohr", "Monahan", "Moore", "Morar", "Morissette", "Mosciski", "Mraz", "Mueller", "Muller", "Murazik", "Murphy", "Murray", "Nader", "Nicolas", "Nienow", "Nikolaus", "Nitzsche", "Nolan", "Oberbrunner", "O\"Connell", "O\"Conner", "O\"Hara", "O\"Keefe", "O\"Kon", "Okuneva", "Olson", "Ondricka", "O\"Reilly", "Orn", "Ortiz", "Osinski", "Pacocha", "Padberg", "Pagac", "Parisian", "Parker", "Paucek", "Pfannerstill", "Pfeffer", "Pollich", "Pouros", "Powlowski", "Predovic", "Price", "Prohaska", "Prosacco", "Purdy", "Quigley", "Quitzon", "Rath", "Ratke", "Rau", "Raynor", "Reichel", "Reichert", "Reilly", "Reinger", "Rempel", "Renner", "Reynolds", "Rice", "Rippin", "Ritchie", "Robel", "Roberts", "Rodriguez", "Rogahn", "Rohan", "Rolfson", "Romaguera", "Roob", "Rosenbaum", "Rowe", "Ruecker", "Runolfsdottir", "Runolfsson", "Runte", "Russel", "Rutherford", "Ryan", "Sanford", "Satterfield", "Sauer", "Sawayn", "Schaden", "Schaefer", "Schamberger", "Schiller", "Schimmel", "Schinner", "Schmeler", "Schmidt", "Schmitt", "Schneider", "Schoen", "Schowalter", "Schroeder", "Schulist", "Schultz", "Schumm", "Schuppe", "Schuster", "Senger", "Shanahan", "Shields", "Simonis", "Sipes", "Skiles", "Smith", "Smitham", "Spencer", "Spinka", "Sporer", "Stamm", "Stanton", "Stark", "Stehr", "Steuber", "Stiedemann", "Stokes", "Stoltenberg", "Stracke", "Streich", "Stroman", "Strosin", "Swaniawski", "Swift", "Terry", "Thiel", "Thompson", "Tillman", "Torp", "Torphy", "Towne", "Toy", "Trantow", "Tremblay", "Treutel", "Tromp", "Turcotte", "Turner", "Ullrich", "Upton", "Vandervort", "Veum", "Volkman", "Von", "VonRueden", "Waelchi", "Walker", "Walsh", "Walter", "Ward", "Waters", "Watsica", "Weber", "Wehner", "Weimann", "Weissnat", "Welch", "West", "White", "Wiegand", "Wilderman", "Wilkinson", "Will", "Williamson", "Willms", "Windler", "Wintheiser", "Wisoky", "Wisozk", "Witting", "Wiza", "Wolf", "Wolff", "Wuckert", "Wunsch", "Wyman", "Yost", "Yundt", "Zboncak", "Zemlak", "Ziemann", "Zieme", "Zulauf" };
	}
}
