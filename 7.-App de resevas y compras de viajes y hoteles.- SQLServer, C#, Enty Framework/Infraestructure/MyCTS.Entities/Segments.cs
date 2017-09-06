using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class Segments
    {
        private readonly List<ISegment> _segments;
        /// <summary>
        /// Initializes a new instance of the <see cref="Segments"/> class.
        /// </summary>
        public Segments()
        {
            _segments = new List<ISegment>();
        }

        public List<ISegment> GetAll()
        {
            return _segments;
        }

        /// <summary>
        /// Adds the specified segments to add.
        /// </summary>
        /// <param name="segmentsToAdd">The segments to add.</param>
        public void Add(List<ISegment> segmentsToAdd)
        {
            _segments.AddRange(segmentsToAdd);
        }
        public string ItineraryString
        {
            get
            {
                if (_segments.Count > 1)
                {
                    var segmentsInAscendingOrder = _segments.OrderBy(s => s.DepartureTime);
                    var fristSegment = segmentsInAscendingOrder.FirstOrDefault();
                    if (fristSegment != null)
                    {
                        string segmentString = string.Format("{0}-{1}", fristSegment.DepartureStation,
                                                             fristSegment.ArrivalStation);
                        var lastSegment = segmentsInAscendingOrder.LastOrDefault();
                        if (lastSegment != null)
                        {
                            segmentString += string.Format("-{0}", lastSegment.ArrivalStation);
                            return segmentString;
                        }
                    }

                }
                else
                {
                    var segment = _segments.FirstOrDefault();
                    if (segment != null)
                    {
                        return string.Format("{0}-{1}", segment.DepartureStation, segment.ArrivalStation);
                    }
                }
                return string.Empty;
            }

        }

        private string _descriptionForToolTip;

        public string DescriptionForToolTip
        {
            get
            {
                if (string.IsNullOrEmpty(_descriptionForToolTip))
                {
                    string toolTipText = "";
                    //if (_segments.Any())
                    //{
                        foreach (var segment in _segments)
                        {
                            toolTipText += string.Format("No de Vuelo: {0}  ", segment.ID);
                        }
                        toolTipText += "\n";
                        foreach (var segment in _segments)
                        {
                            toolTipText += string.Format("{0}-{1}	      ", segment.DepartureStation,
                                                         segment.ArrivalStation);
                        }
                        toolTipText += "\n";
                        foreach (var segment in _segments)
                        {
                            toolTipText += string.Format("Salida :{0}	      ", segment.DepartureTime.ToString("HH:mm"));
                        }
                        toolTipText += "\n";
                        foreach (var segment in _segments)
                        {
                            toolTipText += string.Format("Destino :{0}     ", segment.ArrivalTime.ToString("HH:mm"));
                        }
                        toolTipText += "\n";

                    //}
                    _descriptionForToolTip = toolTipText;

                }
                return _descriptionForToolTip;
            }
        }

        /// <summary>
        /// Adds the specified segment.
        /// </summary>
        /// <param name="segment">The segment.</param>
        public void Add(ISegment segment)
        {
            Add(new List<ISegment> { segment });
        }

        /// <summary>
        /// Removes the specified segments to remove.
        /// </summary>
        /// <param name="segmentsToRemove">The segments to remove.</param>
        public void Remove(List<ISegment> segmentsToRemove)
        {
            var setToRemove = new HashSet<ISegment>(segmentsToRemove);
            if (_segments.Any())
            {
                _segments.RemoveAll(setToRemove.Contains);
            }

        }

        /// <summary>
        /// Removes the specified segment to remove.
        /// </summary>
        /// <param name="segmentToRemove">The segment to remove.</param>
        public void Remove(ISegment segmentToRemove)
        {

            Remove(new List<ISegment> { segmentToRemove });
        }

    }
}
