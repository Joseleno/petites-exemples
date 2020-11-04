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