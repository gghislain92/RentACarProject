﻿using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Response;
using Business.Rules;
using Data_Access.Abstracts;
using Data_Access.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ModelManager : IModelService
    {

        private IModelDal _modelDal;
        ModelBusinessRules rules;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
            rules = new ModelBusinessRules(_modelDal);
        }

        public void Add(CreateModelRequest createModelRequest)
        {

            rules.ModelNameCanNotBeDuplicated(createModelRequest.Name);

            Model model = new Model
            {
                Name = createModelRequest.Name,
                dailyPrice = createModelRequest.dailyPrice,
                BrandId = createModelRequest.BrandId
            };
            _modelDal.Add(model);

        }

        public List<GetModelResponse> GetAll()
        {

            List<Model> models = _modelDal.GetAllWithBrand().ToList();

            List<GetModelResponse> getModelResponses = new List<GetModelResponse>();

            foreach (Model model in models)
            {
                GetModelResponse getModelResponse = new GetModelResponse();
                getModelResponse.Name = model.Name;
                getModelResponse.dailyPrice = model.dailyPrice;
                getModelResponse.Id = model.Id;
                getModelResponse.BrandId = model.BrandId;
                getModelResponse.BrandName = model.Brand.Name;

                getModelResponses.Add(getModelResponse);
            }

            return getModelResponses;

        }

        public List<GetModelResponse> GetAll(string modelName)
        {
            List<Model> models = _modelDal.GetAllWithBrand(modelName).ToList();

            List<GetModelResponse> getModelResponses = new List<GetModelResponse>();

            foreach (Model model in models)
            {
                GetModelResponse getModelResponse = new GetModelResponse();
                getModelResponse.Name = model.Name;
                getModelResponse.dailyPrice = model.dailyPrice;
                getModelResponse.Id = model.Id;
                getModelResponse.BrandId = model.BrandId;
                getModelResponse.BrandName = model.Brand.Name;

                getModelResponses.Add(getModelResponse);
            }

            return getModelResponses;
        }
    }
}
