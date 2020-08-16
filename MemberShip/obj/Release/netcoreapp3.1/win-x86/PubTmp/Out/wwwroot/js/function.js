$(document).ready(function (e) {



    $(function () {

        Highcharts.theme = {
            colors: ['#32c5d2', '#2baeb9', '#0d98b5', '#0b7e96'],
            chart: {}
        };
        // Apply the theme
        Highcharts.setOptions(Highcharts.theme);

        var bgColor = {
            backgroundColor: {
                linearGradient: [0, 0, 500, 500],
                stops: [
        [0, 'rgb(255, 255, 255)'],
        [1, 'rgb(240, 240, 255)']
      ]
            }
        };

    });

    $(function () {
        // Create the chart
        chart = new Highcharts.Chart({
            chart: {
                renderTo: 'status',
                type: 'pie',
                height: 298,

            },
            title: {
                text: ''
            },
            yAxis: {
                title: {
                    text: ''
                },

            },
                dataLabels: {
                    style: {
                        color: '#444444',
                        fontWeight: 'normal'
                    }
                },


            plotOptions: {
                pie: {
                    shadow: false
                },
                series: {
            dataLabels: {
                enabled: true,
                style: {
                    color: '#444444',
                        fontWeight: 'normal'
                }
            }
        }
            },
            credits: {
                enabled: false
            },
            legend: {
                layout: 'vertical',
                padding: 3,
                itemMarginTop: 5,
                itemMarginBottom: 5,
				rtl:true,
                itemStyle: {
                    lineHeight: '14px'
                },
                itemHoverStyle: {
                    color: '#777777'
                },
                itemStyle: {
                    color: '#444444',
                    fontWeight: 'normal'
                },
                labelFormatter: function () {
                    return this.name + '<em>   (    ' + this.y + '  Days' + '   )</em>';
                }
            },
            tooltip: {
                formatter: function () {
                    return '' + this.point.name + '<br> ' + '<span class="legy">' + '  ' + '</span>';
                },

            },
            series: [{
                name: 'Expired date',
                data: [
        ['نوع القضايا', 25],
        ['نوع القضايا', 25],
        ['نوع القضايا', 25],
        ['نوع القضايا', 25],

      ],
                size: '100%',
                innerSize: '40%',
                borderWidth: 4,
                showInLegend: false,



    }]
        });
    });

});