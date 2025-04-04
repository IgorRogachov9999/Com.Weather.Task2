--liquibase formatted sql

--changeset i.rohachov:create_weather_table
CREATE SCHEMA IF NOT EXISTS weather;

CREATE TABLE IF NOT EXISTS weather.weather_info (
    id int PRIMARY KEY,
    country text NOT NULL,
    city text NOT NULL,
    min_value decimal NOT NULL,
    max_value decimal NOT NULL,
    timestamp timestamp NOT NULL
);

--rollback DROP TABLE IF EXISTS weather.weather_info;
--rollback DROP SCHEMA IF EXISTS weather;