using AutoMapper;
using CuKhoaiCuSan.Model.Models;
using CuKhoaiCuSan.Service;
using CuKhoaiCuSan.Web.Infrastructure.Core;
using CuKhoaiCuSan.Web.Infrastructure.Extensions;
using CuKhoaiCuSan.Web.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CuKhoaiCuSan.Web.Api
{
    [RoutePrefix("api/item")]
    public class ItemController : ApiControllerBase
    {
        private IItemService _itemService;

        public ItemController(IErrorService errorService, IItemService itemService) : base(errorService)
        {
            this._itemService = itemService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listItem = _itemService.GetAll();

                var listItemVm = Mapper.Map<List<ItemViewModel>>(listItem);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listItemVm);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ItemViewModel ItemVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Item newItem = new Item();
                    newItem.UpdateItem(ItemVm);
                    newItem.CreateDate = DateTime.Now;
                    newItem.ItemID = new Guid();
                    try
                    {
                        _itemService.Add(newItem);
                        _itemService.SaveChanges();

                        var responseData = Mapper.Map<Item, ItemViewModel>(newItem);
                        response = request.CreateResponse(HttpStatusCode.Created, responseData);
                    }
                    catch
                    {
                    }
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ItemViewModel ItemVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbItem = _itemService.GetByID(ItemVm.ItemID);

                    dbItem.UpdateItem(ItemVm);

                    _itemService.Update(dbItem);
                    _itemService.SaveChanges();

                    var responseData = Mapper.Map<Item, ItemViewModel>(dbItem);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, Guid id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _itemService.Delete(id);
                    _itemService.SaveChanges();

                    var responseData = Mapper.Map<Item, ItemViewModel>(_itemService.GetByID(id));
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
    }
}