using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class DocsFirstLevelBL
    {
        public static bool AddImage(DocsFirstLevel docsEntities)
        {
            try
            {
                return DocsFirstLevelDA.AddImage(docsEntities, CommonENT.MYCTSDBPROFILES_CONNECTION);
            }
            catch (Exception err) { return false; }
        }

        public static bool DeleteImage(DocsFirstLevel docsEntities)
        {
            bool success = false;
            try
            {
                DocsFirstLevelDA.DeleteImage(docsEntities, CommonENT.MYCTSDBPROFILES_CONNECTION);
                success = true;
                return success;
            }
            catch { return success; }
        }

        public static bool UpdateImage(DocsFirstLevel docsEntities)
        {
            bool success = false;
            try
            {
                DocsFirstLevelDA.UpdateImage(docsEntities, CommonENT.MYCTSDBPROFILES_CONNECTION);
                success = true;
                return success;

            }
            catch { return success; }
        }

        public static DocsFirstLevel getImage(int profileId, int imageId)
        {
            DocsFirstLevel docs = new DocsFirstLevel();
            try
            {

                docs = DocsFirstLevelDA.getImage(profileId, imageId, CommonENT.MYCTSDBPROFILES_CONNECTION);
                return docs;

            }
            catch { return docs; }
        }

        public static DocsFirstLevel getImageById(int imageId)
        {
            DocsFirstLevel docs = new DocsFirstLevel();
            try
            {

                docs = DocsFirstLevelDA.getImageById(imageId, CommonENT.MYCTSDBPROFILES_CONNECTION);
                return docs;

            }
            catch { return docs; }
        }

        public static List<DocsFirstLevel> getImageByProfileId(string profileId)
        {
            return DocsFirstLevelDA.getImageByProfileId(profileId, CommonENT.MYCTSDBPROFILES_CONNECTION);

        }
    }
}
