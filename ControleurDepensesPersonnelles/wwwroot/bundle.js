function GetTypeDepenses(donnes) {
    var labels = [];
    var taille = donnes.length;
    var i = 0;

    while (i < taille) {
        labels.push(donnes[i].typeDepense);
        i++;
    }

    return labels;
}

function GetValeurs(donnes) {
    var valeurs = [];
    var taille = donnes.length;
    var i = 0;

    while (i < taille) {
        valeurs.push(donnes[i].valeurs);
        i++;
    }

    return valeurs;
}


function GetCouleurs(qtd) {
    var couleurs = [];

    while (qtd > 0) {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);

        couleurs.push("rgb(" + r + "," + g + "," + r + ")");

        qtd--;
    }
    return couleurs;
}


$(".selectMois").on('change', function () {
    var moisId = $(".selectMois").val();

    $.ajax({
        url: "Depenses/DepenseMois",
        method: "POST",
        data: { moisId: moisId },
        success: function (donnes) {
            $("canvas#GraphiqueDepenseMois").remove();
            $("div.divDepenseMois").append('<canvas id="GraphiqueDepenseMois" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraphiqueDepenseMois').getContext('2d');

            var grafique = new Chart(ctx, {
                type: 'pie',
                data:
                {
                    labels: GetTypeDepenses(donnes),
                    datasets: [
                        {
                            label: "Depénses par type",
                            backgroundColor: GetCouleurs(donnes.length),
                            hoverBackgroundColor: GetCouleurs(donnes.length),
                            data: GetValeurs(donnes)
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: " Depénses par Type"
                    }
                }
            });

        }
    });

});

function ChargerDonnesGraphiqueDepenseMois() {

    var moisId = $(".selectMois").val();

    $.ajax({
        url: "Depenses/DepenseMois",
        method: "POST",
        data: { moisId: moisId },
        success: function (donnes) {
            $("canvas#GraphiqueDepenseMois").remove();
            $("div.divDepenseMois").append('<canvas id="GraphiqueDepenseMois" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraphiqueDepenseMois').getContext('2d');

            var grafique = new Chart(ctx, {
                type: 'pie',
                data:
                {
                    labels: GetTypeDepenses(donnes),
                    datasets: [
                        {
                            label: "Depénses par type",
                            backgroundColor: GetCouleurs(donnes.length),
                            hoverBackgroundColor: GetCouleurs(donnes.length),
                            data: GetValeurs(donnes)
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: " Depénses par Type"
                    }
                }
            });

        }
    });
}
$(".selectMois").on('change', function () {
    var moisId = $(".selectMois").val();

    $.ajax({
        url: "Depenses/DepenseTotalMois",
        method: "POST",
        data: { moisId: moisId },
        success: function (donnes) {
            $("canvas#GraphiqueDepenseTotalMois").remove();
            $("div.divDepenseTotalMois").append('<canvas id="GraphiqueDepenseTotalMois" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraphiqueDepenseTotalMois').getContext('2d');

            var grafique = new Chart(ctx, {
                type: 'doughnut',
                data:
                {
                    labels: ['Solde', 'Depénses'],
                    datasets: [
                        {
                            label: "Depénses",
                            backgroundColor: ["#27ae60", "#c0392b"],
                            data: [(donnes.salaire - donnes.valeurTotalDepense), donnes.valeurTotalDepense]
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text:" Total depénses par Mois"
                    }
                }
            });

        }
    });

});

function ChargerDonnesGraphiqueDepenseTotalMois() {
    
    $.ajax({
        url: "Depenses/DepenseMois",
        method: "POST",
        data: { moisId: 1 },
        success: function (donnes) {
            $("canvas#GraphiqueDepenseTotalMois").remove();
            $("div.divDepenseTotalMois").append('<canvas id="GraphiqueDepenseTotalMois" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraphiqueDepenseTotalMois').getContext('2d');

            var grafique = new Chart(ctx, {
                type: 'doughnut',
                data:
                {
                    labels: ['Solde', 'Depénses'],
                    datasets: [
                        {
                            label: "Depénses",
                            backgroundColor: ["#27ae60", "#c0392b"],
                            data: [(donnes.salaire - donnes.valeurTotalDepense), donnes.valeurTotalDepense]
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: " Total depénses par Mois"
                    }
                }
            });

        }
    });

}
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.