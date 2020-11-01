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

function ChargerDonnesGraphiqueDepenseMois() {
    
    $.ajax({
        url: "Depenses/DepenseMois",
        method: "POST",
        data: { moisId: 1 },
        success: function (donnes) {
            $("canvas#GraphiqueDepenseMois").remove();
            $("div.divDepenseMois").append('<canvas id="GraphiqueDepenseMois" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraphiqueDepenseMois').getContext('2d');

            var grafique = new Chart(ctx, {
                type: 'pie',
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