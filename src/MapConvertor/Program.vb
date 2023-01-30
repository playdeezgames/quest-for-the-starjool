Imports System.IO
Imports System.Text.Json.Serialization
Imports TiledLib.Layer
Imports TiledLib.Objects

Module Program
    Private ReadOnly conversions As New List(Of (String, String)) From
        {
            ("..\..\..\..\..\maps\Overworld.tmx", "..\..\..\..\QuestForTheStarjool\Assets\Maps\Overworld.json"),
            ("..\..\..\..\..\maps\Town1.tmx", "..\..\..\..\QuestForTheStarjool\Assets\Maps\Town1.json")
        }
    Sub Main(args As String())
        For Each conversion In conversions
            ConvertFile(conversion.Item1, conversion.Item2)
        Next
    End Sub

    Private Sub ConvertFile(fromFile As String, toFile As String)
        Dim mapData As New MapData
        Using stream = File.OpenRead(fromFile)
            Dim fromMap = Map.FromStream(stream)
            Dim cellHeight = fromMap.CellHeight
            Dim cellWidth = fromMap.CellWidth
            mapData.DefaultTerrain = CType(fromMap.Properties("DefaultTerrain"), TerrainType)
            For Each l In fromMap.Layers
                Select Case l.LayerType
                    Case LayerType.tilelayer
                        LoadTileLayer(DirectCast(l, TileLayer), mapData)
                    Case LayerType.objectgroup
                        LoadObjectLayer(DirectCast(l, ObjectLayer), mapData, cellWidth, cellHeight)
                    Case Else
                        Throw New NotImplementedException
                End Select
            Next
        End Using
        File.WriteAllText(toFile, JsonSerializer.Serialize(mapData))
    End Sub

    Private Const TriggerTypeProperty = "TriggerType"
    Private Const DestinationMapProperty = "DestinationMap"
    Private Const DestinationXProperty = "DestinationX"
    Private Const DestinationYProperty = "DestinationY"
    Private Const TeleportTriggerTypeName = "Teleport"
    Private Const ShoppeTriggerTypeName = "Shoppe"

    Private Sub LoadObjectLayer(l As ObjectLayer, mapData As MapData, cellWidth As Integer, cellHeight As Integer)
        For Each o In l.Objects.OrderBy(Function(x) CInt(x.Properties("Order")))
            Dim column = CInt(o.X) \ cellWidth
            Dim row = CInt(o.Y) \ cellHeight - 1
            Dim cellIndex = column + row * mapData.Columns
            Select Case o.Properties(TriggerTypeProperty)
                Case TeleportTriggerTypeName
                    AddTeleportTrigger(mapData.Cells(cellIndex), o)
                Case ShoppeTriggerTypeName
                    AddShoppeTrigger(mapData.Cells(cellIndex), o)
                Case Else
                    Throw New NotImplementedException
            End Select
        Next
    End Sub

    Private Sub AddShoppeTrigger(mapCellData As MapCellData, o As BaseObject)
        Dim triggerData As New TriggerData With
            {
                .TriggerType = TriggerType.Shoppe,
                .Shoppe = New ShoppeData With
                {
                    .Offers = ProcessPriceList(o.Properties("Offers")),
                    .Prices = ProcessPriceList(o.Properties("Prices"))
                }
            }
        mapCellData.Triggers.Add(triggerData)
    End Sub

    Private Function ProcessPriceList(input As String) As Dictionary(Of ItemType, Decimal)
        Return JsonSerializer.Deserialize(Of Dictionary(Of Integer, Decimal))(input).
            ToDictionary(Function(x) CType(x.Key, ItemType), Function(x) x.Value)
    End Function

    Private Sub AddTeleportTrigger(mapCellData As MapCellData, o As BaseObject)
        Dim triggerData As New TriggerData With
            {
                .TriggerType = TriggerType.Teleport,
                .Teleport = New TeleportTriggerData With
                {
                    .DestinationMap = o.Properties(DestinationMapProperty),
                    .DestinationX = CInt(o.Properties(DestinationXProperty)),
                    .DestinationY = CInt(o.Properties(DestinationYProperty))
                }
            }
        mapCellData.Triggers.Add(triggerData)
    End Sub

    Private Sub LoadTileLayer(l As TileLayer, mapData As MapData)
        mapData.Columns = l.Width
        mapData.Rows = l.Height
        Dim index = 0
        For row = 0 To mapData.Rows - 1
            For column = 0 To mapData.Columns - 1
                mapData.Cells.Add(New MapCellData With
                    {
                        .Terrain = CType(l.Data(index), TerrainType)
                    })
                index += 1
            Next
        Next
    End Sub
End Module
