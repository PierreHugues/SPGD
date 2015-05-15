using SPGD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPGD.DAL
{
    public class PhotoRepository: GenericRepository<Photo>
    {
        public PhotoRepository(H15_PROJET_E09Entities1 context) : base(context) { }

        public IEnumerable<Photo> GetPhotos()
        {
            return Get();
        }
        public Photo GetPhotoByID(int? id)
        {
            return GetByID(id);
        }
        public void InsertPhoto(Photo photo)
        {
            Insert(photo);
        }
        public void UpdatePhoto(Photo photo)
        {
            Update(photo);
        }
        public void DeletePhoto(int id)
        {
            Delete(id);
        }
    }
}