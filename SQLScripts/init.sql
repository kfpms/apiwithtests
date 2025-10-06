\set ON_ERROR_STOP on

-- 1) Create database if it doesn't exist (runs as a plain statement, not inside a function)
SELECT 'CREATE DATABASE hundredx'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'hundredx') \gexec

-- 2) Switch into the new/existing database
\connect hundredx

-- 3) Create schema, table, and seed data
CREATE SCHEMA IF NOT EXISTS hundredx;

DROP TABLE IF EXISTS hundredx.historical_record;

CREATE TABLE hundredx.historical_record (
  cryptocurrency_id integer NOT NULL,
  record_date date NOT NULL,
  price numeric(38,28),
  supply numeric(38,20),
  volume numeric(38,20),
  rank integer NOT NULL,
  market_cap numeric(38,20),
  CONSTRAINT pk_hundredx_historical_record PRIMARY KEY (cryptocurrency_id, record_date)
);

INSERT INTO hundredx.historical_record
  (cryptocurrency_id, record_date, price, supply, volume, rank, market_cap)
VALUES
  (1, '2023-10-19', 28719.8100000000000000000000000000, 19518531.00000000000000000000, 14448058194.00000000000000000000, 1, 560568426319.99000000000000000000),
  (1, '2019-12-11', 7217.4300000000000000000000000000, 18096462.00000000000000000000, 16350490689.00000000000000000000, 1, 130609895527.99000000000000000000)
  --,
--  (1, '2020-05-11', 8601.8000000000000000000000000000, 18375143.00000000000000000000, 57119858801.00000000000000000000, 1, 158059235275.59000000000000000000);
