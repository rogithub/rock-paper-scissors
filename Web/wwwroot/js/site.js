// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const moveToString = (n) => {
    switch (n) {
        case 0:
          return "Rock";
        case 1:
            return "Paper";
        case 2:
          return "Scissors"
        default:
          throw `Number do not match enum ${n}`;
      }         
};

const post = async (url, body) => {
    const response = await window.fetch(url, {
        method: 'POST',
        mode: 'same-origin', 
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    });

    return await response.json();
}

const playRound = async (userMove) => {
    let res = await post('/home/play', { UserMove: userMove });
    
    $("#tblResults tbody tr").remove();

    for (let i = 0; i < res.rows.length; i++) {
        let row = res.rows[i];
        let tr = $("<tr/>");
        tr.append(`<td>${i}</td>`);
        tr.append(`<td>${row.isTie? "No winner" : row.userWins ? "User": "Server"}</td>`);
        tr.append(`<td>${moveToString(row.userMove)}</td>`);
        tr.append(`<td>${moveToString(row.computerMove)}</td>`);
        $("#tblResults tbody").append(tr);
    }
};

$(async () => {
    $("#frmGame").on("submit", (e) => {
        e.preventDefault();

        let userMove = $("#ddUserPick").val();
        playRound(userMove);
    });

    $("#btnReset").on("click", async () => {
        let res = await post('/home/reset', { });    
        $("#tblResults tbody tr").remove();
    });
});