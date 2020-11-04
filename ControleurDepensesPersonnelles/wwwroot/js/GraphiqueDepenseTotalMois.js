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