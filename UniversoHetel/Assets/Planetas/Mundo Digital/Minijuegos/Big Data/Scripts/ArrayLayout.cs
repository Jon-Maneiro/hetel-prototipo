namespace Planetas.Mundo_Digital.Minijuegos.Big_Data.Scripts
{
	[System.Serializable]
	public class ArrayLayout
	{

		[System.Serializable]
		public struct RowData
		{
			public bool[] row;
		}

		public RowData[] rows = new RowData[8]; //creates a grid with a Y of 8, ultimately controlled by the CustPropertyDrawer.cs

	}
}