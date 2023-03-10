using Matrix.Logic;

var myMatrix = new MyMatrix(5);
myMatrix.Fill();
var mainDiagonal = myMatrix.GetMainDiagonal();
var secondaryDiagonal = myMatrix.GetSecondaryDiagonal();

Console.WriteLine("*** Matrix ***");
Console.WriteLine(myMatrix);
Console.WriteLine("*** Main Diagonal ***");
Console.WriteLine(mainDiagonal);
Console.WriteLine("*** Secondary Diagonal ***");
Console.WriteLine(secondaryDiagonal);
Console.WriteLine("*** Upper Triangular ***");
Console.WriteLine(myMatrix.GetUpperTriangular());
Console.WriteLine("*** Lower Triangular ***");
Console.WriteLine(myMatrix.GetLowerTriangular());
