//var judul = document.getElementById("judul");
//judul.style.backgroundColor = "brown";
//$("#judul").html("berubah dari JQuery").css("background-color", "blue");

//var p = document.getElementsByTagName("p");

//var list = document.querySelector("li:nth-child(2)");

//list.addEventListener("click", function (){
//    p[2].innerHTML = "berubah dari javascript"
//    list.innerHTML = "Lohheee... tadi warna... napa skrng tulisan kok ikut berubah.. kenapa hayoo???"
//})
//list.addEventListener("mouseover", function () {
//    p[1].style.backgroundColor = "red"
//    list.style.backgroundColor = "silver"
//    list.innerHTML = "Loh.. napa warna yg di atas jadi gini dah???"
//})

//document.querySelector("li:nth-child(3)").style.backgroundColor = "palegreen";
//var x = document.querySelectorAll(".col-6");
//var a = document.querySelectorAll(".col-sm-4");
//var z = document.querySelectorAll(".col-sm-3");
//x.forEach(y => {
//    y.addEventListener('mouseover', function () {
//        y.style.backgroundColor = "yellow"
//    });
//});

//z.forEach(y => {
//    y.addEventListener('mouseover', function () {
//        y.style.backgroundColor = "palegreen"
//    });
//});

//a.forEach(y => {
//    y.addEventListener('mouseover', function () {
//        y.style.backgroundColor = "pink"
//    });
//});

//animals, ambil yg cat doang, sama yg fish ganti class name jadi non mamalia
//isi animals=> name, species, class=>name
//const animals = [
//    { name: "Dory", species: "fish", class: {name: "invertebrata"} },
//    { name: "Garfield", species: "cat", class: {name: "mamalia"} },
//    { name: "Angela", species: "cat", class: {name: "mamalia"} },
//    { name: "Nemo", species: "fish", class: {name: "invertebrata"} },
//    { name: "Tom", species: "cat", class: {name: "mamalia"} }
//]

//let onlyCat = [];
//for (var i = 0; i < animals.length; i++) {
//    if (animals[i].species == "cat") {
//        onlyCat.push(animals[i]);
//    }
//    if (animals[i].class.name == "invertebrata") {
//        animals[i].class.name = "non-mamalia";
//    }
//}
//let onlyFish = animals.filter(x => x.species=="fish");
//console.log(onlyFish);
//onlyCat[0].name = "Bojack"
//console.log(onlyCat);
//console.log(animals);

//consume API

//ajax = asynchronus javascript and xml
//$.ajax({
//    url: "https://pokeapi.co/api/v2/pokemon/?offset=0&limit=146"
//}).done((result) => {
//    console.log(result);
//    let text = "";
//    $.each(result.results, function (key, val) {
//        //console.log(val.name);
//        text += `<tr> 
//                    <td>${key + 1}</td>
//                    <td>${val.name}</td>
//                    <td>
//                        <button onclick="detailPoke('${val.url}')" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalPoke">
//                          Detail
//                        </button>
//                    </td>
//                </tr>`;
//    })
//    //console.log(text);
//    $("#tbodyPoke").html(text);
//});

function detailPoke(urlPoke) {

    $.ajax({
        url: urlPoke
    }).done((result) => {
        console.log(result);
        pokeName = result.name;
        text = `<img src="${result.sprites.other.dream_world.front_default}"><br>`;
        $.each(result.types, function (key, val) {
            typeName = val.type.name
            if (typeName == 'grass') {
                text += `<span class="badge badge-pill" id="grass">${typeName}</span> `;
            } else if (typeName == 'poison') {
                text += `<span class="badge badge-pill" id="poison">${typeName}</span> `;
            } else if (typeName == 'fire') {
                text += `<span class="badge badge-pill" id="fire">${typeName}</span> `;
            } else if (typeName == 'flying') {
                text += `<span class="badge badge-pill" id="flying">${typeName}</span> `;
            } else if (typeName == 'water') {
                text += `<span class="badge badge-pill" id="water">${typeName}</span> `;
            } else if (typeName == 'bug') {
                text += `<span class="badge badge-pill" id="bug">${typeName}</span> `;
            } else if (typeName == 'ground') {
                text += `<span class="badge badge-pill" id="ground">${typeName}</span> `;
            } else if (typeName == 'dark') {
                text += `<span class="badge badge-pill" id="dark">${typeName}</span> `;
            } else if (typeName == 'steel') {
                text += `<span class="badge badge-pill" id="steel">${typeName}</span> `;
            } else if (typeName == 'electric') {
                text += `<span class="badge badge-pill" id="electric">${typeName}</span> `;
            } else if (typeName == 'ice') {
                text += `<span class="badge badge-pill" id="ice">${typeName}</span> `;
            } else if (typeName == 'psychic') {
                text += `<span class="badge badge-pill" id="psychic">${typeName}</span> `;
            } else if (typeName == 'fairy') {
                text += `<span class="badge badge-pill" id="fairy">${typeName}</span> `;
            } else if (typeName == 'fighting') {
                text += `<span class="badge badge-pill" id="fighting">${typeName}</span> `;
            } else if (typeName == 'rock') {
                text += `<span class="badge badge-pill" id="rock">${typeName}</span> `;
            } else {
                text += `<span class="badge badge-pill badge-secondary">${typeName}</span> `;
            }
        })
        text += `<h2>${pokeName}</h2>`;

        //Stats Text
        statsText = `<h5>statistics</h5>`;
        $.each(result.stats, function (key, val) {
            statsText += `<label>${val.stat.name}</label>`
            baseStat = val.base_stat;
            if (baseStat > 75) {
                statsText += `<div class="progress">
                                <div class="progress-bar" id="lv4stat" role="progressbar" style="width: ${baseStat}%" aria-valuenow="${baseStat}" aria-valuemin="0" aria-valuemax="100">${baseStat}</div>
                              </div>`;
            } else if (75 >= baseStat && baseStat > 50) {
                statsText += `<div class="progress">
                                <div class="progress-bar" id="lv3stat" role="progressbar" style="width: ${baseStat}%" aria-valuenow="${baseStat}" aria-valuemin="0" aria-valuemax="100">${baseStat}</div>
                              </div>`;
            } else if (50 >= baseStat && baseStat > 25) {
                statsText += `<div class="progress">
                                <div class="progress-bar" id="lv2stat" role="progressbar" style="width: ${baseStat}%" aria-valuenow="${baseStat}" aria-valuemin="0" aria-valuemax="100">${baseStat}</div>
                              </div>`;
            } else {
                statsText += `<div class="progress">
                                <div class="progress-bar" id="lv1stat" role="progressbar" style="width: ${baseStat}%" aria-valuenow="${baseStat}" aria-valuemin="0" aria-valuemax="100">${baseStat}</div>
                              </div>`;
            }
        })

        //abilities text 
        abilityText = `<h5>abilities</h5>`;
        $.each(result.abilities, function (key, val) {
            if (!val.is_hidden) {
                abilityText += `<li class="list-group-item d-flex justify-content-between align-items-center">
                                    ${val.ability.name}
                                </li>`;
            } else {
                abilityText += `<li class="list-group-item d-flex justify-content-between align-items-center">
                                    ${val.ability.name}
                                    <span class="badge badge-dark badge-pill">Hidden Ability</span>
                                </li>`;
            }
        })

        infoText = `<tr> 
                        <td>${result.height / 10} m</td>
                        <td>${result.weight / 10} kg</td>
                    </tr>`;

        $(".modal-title").html("Details of " + pokeName);
        $("#imgninfo").html(text);
        $(".stats-box").html(statsText);
        $(".list-group").html(abilityText);
        $("#table-info").html(infoText);
    }).fail((error) => {

    });

}

$(document).ready(function () {
    $('#tablePoke').DataTable({
        "ajax": {
            "url": "https://pokeapi.co/api/v2/pokemon/?offset=0&limit=150",
            "dataType": "json",
            "dataSrc": "results"
        },
        "columns": [
            {
                "data": "id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "name"
            },
            {
                data: null,
                orderable: false,
                render: function (data, type, row) {
                    return `<button type="button" onclick="detailPoke('${row['url']}')" class="btn btn-primary" data-toggle="modal" data-target="#modalPoke">
                          Detail
                        </button>`
                }
            }
        ]
    });
});
