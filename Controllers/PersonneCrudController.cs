using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gestion_personne_arpilabe.Models;

namespace Gestion_personne_arpilabe.Controllers
{
    public class PersonneCrudController : ApiController
    {
        exoArpilabeEntities arpbdd = new exoArpilabeEntities();
        public IHttpActionResult getPersonne()
        {
            
            var result = arpbdd.personne.ToList();
            return Ok(result);
        }
    [HttpPost]
    public IHttpActionResult personneInsert(personne personneInsert)
        {
            arpbdd.personne.Add(personneInsert);
            arpbdd.SaveChanges();
            return Ok();
        }

    public IHttpActionResult GetPersonneId(int id)
        {
            Personne personneDetails = null;
            personneDetails = arpbdd.personne.Where(x => x.id == id).Select(x => new Personne()
            {
                Id = x.id,
                Prenom = x.prenom,
                Nom = x.nom,
                Mail = x.mail,
                Telephone = x.telephone,
                Note = x.note,
                Departement = x.departement,
                DateDeNaissance = x.dateDeNaissance,
            }).FirstOrDefault<Personne>();
            if (personneDetails == null)
            {
                return NotFound();
            }
            return Ok(personneDetails);
        }

        public IHttpActionResult Put(Personne p)
        {
            var updatePersonne = arpbdd.personne.Where(x => x.id == p.Id).FirstOrDefault<personne>();
            if (updatePersonne != null)
            {
                updatePersonne.id = p.Id;
                updatePersonne.prenom = p.Prenom;
                updatePersonne.nom = p.Nom;
                updatePersonne.mail = p.Mail;
                updatePersonne.note = p.Note;
                updatePersonne.departement = p.Departement;
                updatePersonne.dateDeNaissance = p.DateDeNaissance;
                arpbdd.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
               
        }

        public IHttpActionResult Delete(int id)
        {
            var personneDel = arpbdd.personne.Where(x => x.id == id).FirstOrDefault();
            arpbdd.Entry(personneDel).State = System.Data.Entity.EntityState.Deleted;
            arpbdd.SaveChanges();
            return Ok();
        }
    }
}
