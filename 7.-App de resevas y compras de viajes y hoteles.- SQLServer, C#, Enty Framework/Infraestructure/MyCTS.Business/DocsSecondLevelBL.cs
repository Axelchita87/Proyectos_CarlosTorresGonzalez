using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class DocsSecondLevelBL
    {

        public static bool AddImage(DocsSecondLevel docsEntities)
        {
            try
            {
                return DocsSecondLevelDA.AddImage(docsEntities, CommonENT.MYCTSDBPROFILES_CONNECTION);
            }
            catch (Exception err) { return false; }
        }

        public static bool DeleteImage(DocsSecondLevel docsEntities)
        {
            bool success = false;
            try
            {
                DocsSecondLevelDA.DeleteImage(docsEntities, CommonENT.MYCTSDBPROFILES_CONNECTION);
                    success = true;
                    return success;

            }
            catch { return success; }
        }

        public static bool UpdateImage(DocsSecondLevel docsEntities)
        {
            bool success = false;
            try
            {
                DocsSecondLevelDA.UpdateImage(docsEntities, CommonENT.MYCTSDBPROFILES_CONNECTION);
                    success = true;
                    return success;

            }
            catch { return success; }
        }

        public static DocsSecondLevel  getImage(int profileId, int imageId)
        {
            DocsSecondLevel docs = new DocsSecondLevel();
            try
            {
               
                docs= DocsSecondLevelDA.getImage(profileId, imageId, CommonENT.MYCTSDBPROFILES_CONNECTION);
            return docs;

            }
            catch { return docs; }
        }

        public static DocsSecondLevel getImageById( int imageId)
        {
            DocsSecondLevel docs = new DocsSecondLevel();
            try
            {

                docs = DocsSecondLevelDA.getImageById( imageId, CommonENT.MYCTSDBPROFILES_CONNECTION);
                return docs;

            }
            catch { return docs; }
        }

        public static List<DocsSecondLevel> getImageByProfileId(int profileId)
        {
            return DocsSecondLevelDA.getImageByProfileId(profileId, CommonENT.MYCTSDBPROFILES_CONNECTION);
           
        }
    }
}
