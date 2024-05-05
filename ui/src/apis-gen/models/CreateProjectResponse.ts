/* tslint:disable */
/* eslint-disable */
/**
 * Qz.WebApi
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { mapValues } from '../runtime';
import type { Project } from './Project';
import {
    ProjectFromJSON,
    ProjectFromJSONTyped,
    ProjectToJSON,
} from './Project';

/**
 * 
 * @export
 * @interface CreateProjectResponse
 */
export interface CreateProjectResponse {
    /**
     * 
     * @type {Project}
     * @memberof CreateProjectResponse
     */
    project?: Project;
}

/**
 * Check if a given object implements the CreateProjectResponse interface.
 */
export function instanceOfCreateProjectResponse(value: object): boolean {
    return true;
}

export function CreateProjectResponseFromJSON(json: any): CreateProjectResponse {
    return CreateProjectResponseFromJSONTyped(json, false);
}

export function CreateProjectResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): CreateProjectResponse {
    if (json == null) {
        return json;
    }
    return {
        
        'project': json['project'] == null ? undefined : ProjectFromJSON(json['project']),
    };
}

export function CreateProjectResponseToJSON(value?: CreateProjectResponse | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'project': ProjectToJSON(value['project']),
    };
}
