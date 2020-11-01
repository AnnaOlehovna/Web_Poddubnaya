using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DAL.Entities;

namespace WebApp.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }

        /// <summary>
        /// Сумма
        /// </summary>
        public int PriceSum
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity *
                item.Value.Certificate.Price);
            }
        }

        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="certificate">добавляемый объект</param>
        public virtual void AddToCart(Certificate certificate)
        {
            // если объект есть в корзине
            // то увеличить количество
            if (Items.ContainsKey(certificate.CertificateId))
                Items[certificate.CertificateId].Quantity++;
            // иначе - добавить объект в корзину
            else
                Items.Add(certificate.CertificateId, new CartItem
                {
                    Certificate = certificate,
                    Quantity = 1
                });
        }

        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {

            Items.Remove(id);
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }

    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Certificate Certificate { get; set; }
        public int Quantity { get; set; }
    }
}
