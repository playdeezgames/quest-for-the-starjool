dotnet publish ./src/QuestForTheStarjool/QuestForTheStarjool.vbproj -o ./pub-linux -c Release --sc -r linux-x64
dotnet publish ./src/QuestForTheStarjool/QuestForTheStarjool.vbproj -o ./pub-windows -c Release --sc -r win-x64
butler push pub-windows thegrumpygamedev/quest-for-the-starjool:windows
butler push pub-linux thegrumpygamedev/quest-for-the-starjool:linux
git add -A
git commit -m "shipped it!"