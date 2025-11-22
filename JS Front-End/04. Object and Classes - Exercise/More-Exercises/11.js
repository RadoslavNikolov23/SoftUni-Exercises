function solve(inputArr) {

    class Book{
        constructor(title, author, genre){
            this.title=title;
            this.author=author;
            this.genre=genre;
        }
    }

    let shelves={};

    const patterns = {
        addShelf:/^(\d+)\s+->\s+([\w-]+)$/,
        addBook:/^(.+):\s+(.+),\s+([\w-]+)$/
    }

    for (let element of inputArr) {
        let shelfMatch = element.match(patterns.addShelf);
        let bookMatch = element.match(patterns.addBook);

        if(shelfMatch){

            let [_, shelfId, genre]=shelfMatch;

            if(!shelves[shelfId]){
                shelves[shelfId]={genre:genre, books:[]};
            }

        } else if(bookMatch){

            let [_, title, author, genre]=bookMatch;

            for(let shelfId in shelves){
                if(shelves[shelfId].genre===genre){
                    let book=new Book(title, author, genre);
                    shelves[shelfId].books.push(book);
                }
            }

        }
    }

    let sortedShelves=Object.entries(shelves)
                            .sort((a,b)=>b[1].books.length - a[1].books.length);

    for(let [shelfId, shelfData] of sortedShelves){
        console.log(`${shelfId} ${shelfData.genre}: ${shelfData.books.length}`);

        let sortedBooks=shelfData.books
                                .sort((a,b)=>a.title.localeCompare(b.title));

        for(let book of sortedBooks){
            console.log(`--> ${book.title}: ${book.author}`);
        }
    }

}

solve([
  "1 -> history",
  "1 -> action",
  "Death in Time: Criss Bell, mystery",
  "2 -> mystery",
  "3 -> sci-fi",
  "Child of Silver: Bruce Rich, mystery",
  "Hurting Secrets: Dustin Bolt, action",
  "Future of Dawn: Aiden Rose, sci-fi",
  "Lions and Rats: Gabe Roads, history",
  "2 -> romance",
  "Effect of the Void: Shay B, romance",
  "Losing Dreams: Gail Starr, sci-fi",
  "Name of Earth: Jo Bell, sci-fi",
  "Pilots of Stone: Brook Jay, history",
]);

solve([
  "1 -> mystery",
  "2 -> sci-fi",
  "Child of Silver: Bruce Rich, mystery",
  "Lions and Rats: Gabe Roads, history",
  "Effect of the Void: Shay B, romance",
  "Losing Dreams: Gail Starr, sci-fi",
  "Name of Earth: Jo Bell, sci-fi",
]);
