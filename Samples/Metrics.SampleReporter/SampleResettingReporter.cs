﻿using System;
using System.Threading;
using Metrics.MetricData;
using Metrics.Reporters;

namespace Metrics.SampleReporter
{
    public class SampleResettingReporter : MetricsReport
    {
        public void RunReport(MetricsData metricsData, Func<HealthStatus> healthStatus, CancellationToken token)
        {
            foreach (var timer in metricsData.Timers)
            {
                var timerValue = timer.ValueProvider.GetValue(resetMetric: true);

                Console.WriteLine("{0} : {1} {2} {3}", timer.Name, timerValue.Rate.Count, timerValue.Histogram.Count, timerValue.Histogram.Percentile75);
            }
        }
    }
}
