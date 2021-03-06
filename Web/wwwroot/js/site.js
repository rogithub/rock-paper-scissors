﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const getRowClass = (row) => {
    if (row.isTie) return "";    
    return row.userWins ? "table-success" : "table-danger";
}

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

const showData = (res) => {
    $("#tblResults tbody tr").remove();

    for (let i = res.rows.length - 1; i > -1; i--) {
        let row = res.rows[i];
        
        let tr = $("<tr/>").addClass(getRowClass(row));
        tr.append(`<td>${i}</td>`);
        tr.append(`<td>${row.isTie? "No winner" : row.userWins ? "User": "Server"}</td>`);
        tr.append(`<td>${moveToString(row.userMove)}</td>`);
        tr.append(`<td>${moveToString(row.computerMove)}</td>`);
        $("#tblResults tbody").append(tr);
    }

    $("#lblTotalRounds").text(`${res.stats.totalRounds}`);
    $("#lblUserWins").text(`${res.stats.userWinsCount} (${res.stats.userWinsPercent} %)`);
    $("#lblServerWins").text(`${res.stats.computerWinsCount} (${res.stats.computerWinsPercent} %)`);
    $("#lblTies").text(`${res.stats.tiesCount} (${res.stats.tiesPercent} %)`);
}

const playRound = async (userMove) => {
    let res = await post('/home/play', { UserMove: userMove });
    showData(res);
};

$(async () => {
    $("#frmGame").on("submit", (e) => {
        e.preventDefault();

        let userMove = $("#ddUserPick").val();
        playRound(userMove);
    });

    $("#btnReset").on("click", async () => {
        let res = await post('/home/reset', { });    
        showData(res);
    });
});