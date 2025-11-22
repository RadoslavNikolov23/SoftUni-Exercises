function songs(arrInput) {

  class Song {
    constructor(typeList, name, time) {
      this.typeList = typeList;
      this.name = name;
      this.time = time;
    }

  }

  const numberOfSongs = arrInput.shift();
  const typeListFilter = arrInput.pop();

  let songsCollection = [];

  for(let i=0;i<numberOfSongs;i++){
    let [typeList,name,time] = arrInput[i].split("_");
    let songObj = new Song(typeList,name,time);
    songsCollection.push(songObj);
  }

    for(let song of songsCollection){
        if(song.typeList === typeListFilter || typeListFilter === "all"){
            console.log(song.name);
        }
    }
 

  
  
}

songs([
  3,
  "favourite_DownTown_3:14",
  "favourite_Kiss_4:16",
  "favourite_Smooth Criminal_4:01",
  "favourite",
]);

songs([
  4,
  "favourite_DownTown_3:14",
  "listenLater_Andalouse_3:24",
  "favourite_In To The Night_3:58",
  "favourite_Live It Up_3:48",
  "listenLater",
]);

songs([
    2, 
    "like_Replay_3:15", 
    "ban_Photoshop_3:48", 
    "all"
]);
