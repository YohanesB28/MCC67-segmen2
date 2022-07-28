//const labels = [
//    'January',
//    'February',
//    'March',
//    'April',
//    'May',
//    'June',
//];

//const data = {
//    labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
//    datasets: [{
//        label: '# of Votes',
//        data: [12, 19, 3, 5, 2, 3],
//        backgroundColor: [
//            'rgba(255, 99, 132, 0.2)',
//            'rgba(54, 162, 235, 0.2)',
//            'rgba(255, 206, 86, 0.2)',
//            'rgba(75, 192, 192, 0.2)',
//            'rgba(153, 102, 255, 0.2)',
//            'rgba(255, 159, 64, 0.2)'
//        ],
//        borderColor: [
//            'rgba(255, 99, 132, 1)',
//            'rgba(54, 162, 235, 1)',
//            'rgba(255, 206, 86, 1)',
//            'rgba(75, 192, 192, 1)',
//            'rgba(153, 102, 255, 1)',
//            'rgba(255, 159, 64, 1)'
//        ],
//        borderWidth: 1
//    }]
//};

//const config = {
//    type: 'pie',
//    data: data,
//    options: {}
//};

//const myChart = new Chart(
//    document.getElementById('myChart'),
//    config
//);

$.ajax({
    url: "https://localhost:44318/api/Product"
}).done((result) => {
    let data = result.data;
    let onlyIndofood = data.filter(x => x.suppliers.name == "PT Indofood");
    let onlyKDK = data.filter(x => x.suppliers.name == "PT Kacang Dua Kelinci");
    let onlyUltJay = data.filter(x => x.suppliers.name == "PT Ultra Jaya");
    let onlySidoMuncul = data.filter(x => x.suppliers.name == "PT Sido Muncul");
    let onlySinarSosro = data.filter(x => x.suppliers.name == "PT Sinar Sosro");
    let onlySinarmas = data.filter(x => x.suppliers.name == "PT Sinar Mas");

    const labels = [
        'PT Indofood',
        'PT Kacang Dua Kelinci',
        'PT Ultra Jaya',
        'PT Sido Muncul',
        'PT Sinar Sosro',
        'PT Sinar Mas',
    ];

    const dataChart = {
        labels: labels,
        datasets: [{
            label: 'Count of Supplier',
            data: [onlyIndofood.length, onlyKDK.length, onlyUltJay.length, onlySidoMuncul.length, onlySinarSosro.length, onlySinarmas.length],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
            borderWidth: 1
        }]
    };

    const config1 = {
        type: 'bar',
        data: dataChart,
        options: {}
    };

    const myChart = new Chart(
        document.getElementById('myChart'),
        config1
    );

    //Download Chart Image
    document.getElementById("download").addEventListener('click', function () {
        /*Get image of canvas element*/
        var url_base64jp = document.getElementById("myChart").toDataURL("image/jpg");
        /*get download button (tag: <a></a>) */
        var a = document.getElementById("download");
        /*insert chart image url to download button (tag: <a></a>) */
        a.href = url_base64jp;
    });
});
